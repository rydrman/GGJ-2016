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

		//TODO update the game state based on the decision set actions
		dayController.decisionSet.Destroy ();
		sceneController.ShowNight ();
		isDay = false;
	}

	DecisionSet GenerateDecisionSet() {
		DecisionSet set = new DecisionSet ();


		//TODO newspapers
		foreach(City city in gameState.cities) {
			//pick a topic at random
			Topic topic = TopicUtil.Random ();
			//get the value of that topic
			//for now pick a random newspaper for each city
			DecisionDefinition def = NewspaperDecisions.GetRandom ();
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
