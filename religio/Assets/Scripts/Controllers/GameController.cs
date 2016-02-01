using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

[System.Serializable]
public class GameController : MonoBehaviour {

	public PrefabList prefabs;
	public GameState gameState;
	public SceneController sceneController;
	public DayController dayController; 
	public CityController cityController;
	public GameObject mapObject;

	public int dayLengthSeconds = 30;

	GameObject mainCamera;
	GameObject mapCamera;
	public GameObject transitionUI;

	float lastChange;
	bool isDay = false;
	bool isMap = false;

	bool isStartCanvas = false;
	bool isEndCanvas = false;

	int currentLevel = 0;
	bool levelLoading = true;

	GameController() {
	}

	public void Start() {

		mapCamera = GameObject.Find ("MapCamera");
		mainCamera = GameObject.Find ("Main Camera");

		DontDestroyOnLoad (GameObject.Find ("EventSystem"));
		DontDestroyOnLoad (transitionUI);
		DontDestroyOnLoad (this);
		DontDestroyOnLoad (sceneController);
		DontDestroyOnLoad (dayController);
		DontDestroyOnLoad (cityController);
		DontDestroyOnLoad (mapObject);
		DontDestroyOnLoad (gameState);
		DontDestroyOnLoad (prefabs);
		DontDestroyOnLoad (mapCamera);
		ToggleMap (false);
	}

	public void Update() {

		if(levelLoading) {
			return;
		}
		if(isStartCanvas && Time.time > lastChange + 3) {
			BeginDay ();
			transitionUI.GetComponent<TransitionUIController> ().InactiveAll ();
			isStartCanvas = false;
			lastChange = Time.time;
		}

		else if(isDay && Time.time > lastChange + dayLengthSeconds) {
			EndDay ();
			transitionUI.GetComponent<TransitionUIController> ().ShowEndDay ();
			isEndCanvas = true;
			lastChange = Time.time;
		}

		else if(isEndCanvas && Time.time > lastChange + 3) {
			transitionUI.GetComponent<TransitionUIController> ().InactiveAll ();
			transitionUI.GetComponent<TransitionUIController> ().ShowNextButton ();
			isEndCanvas = false;
			lastChange = Time.time;
		}

		if (isDay && Input.GetKeyDown(KeyCode.Tab)) {
			Debug.Log ("toggle map");
			ToggleMap ();
		}
	}

	public void BeginGame() {
		StartNextDay(1);
	}

	public void OnLevelWasLoaded(int level) {
		currentLevel = level;
		levelLoading = false;
		mainCamera = GameObject.Find ("Main Camera");
		GameObject scene = GameObject.Find("DayScene");
		if (null != scene) scene.GetComponent<SceneHotkeys>().Randomize();
	}
	public void ToggleMap(bool newState) {
		isMap = !newState;
		ToggleMap ();
	}

	public void ToggleMap() {
		if (!isMap) {
			mapObject.SetActive (true);
			mapCamera.SetActive(true);
			mainCamera.SetActive(false);
			isMap = true;
		}
		else {
			mapObject.SetActive (false);
			mainCamera.SetActive(true);
			mapCamera.SetActive(false);
			isMap = false;
		}
	}

	public void StartNextDay(int level) {
		if(level != currentLevel){
			SceneManager.LoadScene (level);
			levelLoading = true;
		}
		ToggleMap (true);
		transitionUI.GetComponent<TransitionUIController> ().ShowStartDay ();
		lastChange = Time.time;
		isStartCanvas = true;
	}

	void BeginDay() {
		//generate the decisions based on the current game state
		DecisionSet decisions = GenerateDecisionSet ();

		// populate the scene with decisions
		dayController.Populate (decisions);

		isDay = true;
		ToggleMap (false);
	}

	public void EndDay() {

		isDay = false;
		//update the game state based on the decision set actions
		DecisionSet decisions = dayController.decisionSet;
		//newspapers
		foreach(GameObject paper in decisions.newspapers) {
			NewspaperDecision decision = paper.GetComponent<NewspaperDecision> ();
			if(null == decision.choice) {
				//no decision was made default to 'negative' effect
				//relative to 1/10th your current stance
				int effect = -gameState.player.GetStance(decision.definition.topic);
				effect = (int)(effect * 0.1f);
				gameState.player.ChangeStance (decision.definition.topic, effect);
			}
			else {
				//enforce the result
				gameState.player.ChangeStance (decision.definition.topic, decision.choice.value);
			}

		}
		//docets
		foreach(GameObject docet in decisions.docets) {
			DocketDecision decision = docet.GetComponent<DocketDecision> ();
			if(null == decision.choice) {
				//no decision was made default to 'negative' effect
				//relative to 1/10th your current stance
				int effect = -gameState.player.GetStance(decision.definition.topic);
				effect = (int)(effect * 0.1f);
				gameState.player.ChangeStance (decision.definition.topic, effect);
			}
			else {
				//enforce the result
				gameState.player.ChangeStance (decision.definition.topic, decision.choice.value);
			}

		}
		//TODO momos

		int delta = gameState.RecalculateFollowers ();
		Debug.Log ("Change in followers: " + delta);

		dayController.decisionSet.Destroy ();
		ToggleMap (true);
		//sceneController.ShowNight ();
	}

	DecisionSet GenerateDecisionSet() {
		DecisionSet set = new DecisionSet ();

		//newspapers
		foreach(City city in gameState.cities) {
			//pick a topic at random
			Topic topic = TopicUtil.Random ();
			//Get a Random article related to the selected topic
			DecisionDefinition def = NewspaperDecisions.GetRandomForTopic (topic);
			if(null == def) {
				Debug.Log ("Could not find article for topic: " + TopicUtil.ToString (topic));
				continue;
			}
			GameObject paper = Instantiate (prefabs.newspaper);
			Dictionary<string, string> values = new Dictionary<string, string>();
			values["CityName"] = city.name;
			values ["Topic"] = TopicUtil.ToString (topic);
			paper.GetComponent<NewspaperDecision>().Define(def, values);
			set.newspapers.Add (paper);
		}

		//docets
		foreach(City city in gameState.cities) {
			//pick a topic at random
			Topic topic = TopicUtil.Random ();
			//Get a Random article related to the selected topic
			DocketDecisionDefinition def = DocketDecisions.GetRandomForTopic (topic);
			if(null == def) {
				Debug.Log ("Could not find docket for topic: " + TopicUtil.ToString (topic));
				continue;
			}
			GameObject docket = Instantiate (prefabs.docet);
			Dictionary<string, string> values = new Dictionary<string, string>();
			values["CityName"] = city.name;
			values ["CharacterType"] = "" + def.personType;
			values ["Topic"] = TopicUtil.ToString (topic);
			def.org = city;
			docket.GetComponent<DocketDecision>().Define(def, values);
			set.docets.Add (docket);
		}
		//TODO memos
		return set;
	}
}
