using System;
using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class GameController : MonoBehaviour {

	public PrefabList prefabs;
	public GameState gameState;
	public SceneController sceneController;
	public DayController dayController; 
	public CityController cityController;

	public int dayLengthSeconds = 30;

	float dayStart;
	bool isDay = false;

	GameController() {
	}

	public void Awake() {
		DontDestroyOnLoad (this);
		DontDestroyOnLoad (sceneController);
		DontDestroyOnLoad (cityController);
		DontDestroyOnLoad (gameState);
		DontDestroyOnLoad (prefabs);
	}

	public void Update() {

		if (!isDay) {
			StartNextDay ();
		}

		if(Time.time > dayStart + dayLengthSeconds) {
			EndDay ();
		}
	}

	public void StartNextDay() {

		//generate the decisions based on the current game state
		DecisionSet decisions = GenerateDecisionSet ();
		dayController.Populate (decisions);

		//hide the map view / change to day
		sceneController.ShowDay ();

		isDay = true;
		dayStart = Time.time;
	}

	public void EndDay() {

		//update the game state based on the decision set actions
		DecisionSet decisions = dayController.decisionSet;
		//newspapers
		foreach(NewspaperDecision decision in decisions.newspapers) {
			if(null == decision.choice) {
				//no decision was made default to 'negative' effect
				//relative to 1/10th your current stance
				int effect = -gameState.player.GetStance(decision.definition.topic);
				effect *= 0.1;
				gameState.player.ChangeStance (decision.definition.topic, effect);
			}
			else {
				//enforce the result
				gameState.player.ChangeStance (decision.definition.topic, decision.choice.value);
			}

		}
		//TODO docets
		//TODO momos

		dayController.decisionSet.Destroy ();
		sceneController.ShowNight ();
		isDay = false;
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

		//TODO docets
		//TODO memos
		return set;
	}
}
