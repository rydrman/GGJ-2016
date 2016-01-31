using UnityEngine;
using System.Collections;

public class FeatureSelector : MonoBehaviour {

	public GameObject[] features;

	void Reset () {
	}

	// Use this for initialization
	void Start () {
		SelectRandomFeature();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void SelectRandomFeature () {
		int choice = Random.Range(0, features.Length);
		int i = 0;
		foreach (GameObject o in features) {
			if (i == choice)
				o.SetActive(true);
			else
				o.SetActive(false);
			i += 1;
		}
	}

	void OnMouseDown () {
		SelectRandomFeature();
	}
}
