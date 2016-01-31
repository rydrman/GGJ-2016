using System;
using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class GameController : MonoBehaviour {

	public PrefabList prefabs;
	public GameState gameState;
	public DayController dayController;
	public SceneController sceneController; 

	public int dayLengthSeconds = 30;

	float dayStart;
	bool isDay = false;

	GameController() {
	}

	public void Awake() {
		DontDestroyOnLoad (this);
		DontDestroyOnLoad (sceneController);
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
			//for now pick a random newspaper for each city
			DecisionDefinition def = NewspaperDecisions.GetRandom ();
			GameObject paper = Instantiate (prefabs.newspaper);
			Dictionary<string, string> values = new Dictionary<string, string>();
			values["CityName"] = city.name;
			paper.GetComponent<NewspaperDecision>().Define(def, values);
			set.newspapers.Add (paper);
		}

		//TODO docets
		//TODO memos
		return set;
	}
}
