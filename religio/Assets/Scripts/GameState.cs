using UnityEngine;
using System;

[System.Serializable]
public class GameState : MonoBehaviour {

	[System.NonSerialized]
	public Organization player;

	public City[] cities;
	//public List<Organization> corporations;

	public GameState() {
	}

	public void Start() {
	}
}
