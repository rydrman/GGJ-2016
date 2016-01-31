using UnityEngine;
using System.Collections;

public class CityMenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ToggleVisibility (bool visible) {
		gameObject.GetComponent<Canvas>().enabled = visible;
		gameObject.GetComponent<BoxCollider> ().enabled = visible;
	}
}
