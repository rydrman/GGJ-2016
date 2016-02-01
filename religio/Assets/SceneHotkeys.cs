using UnityEngine;
using System.Collections;

public class SceneHotkeys : MonoBehaviour {

	public GameObject[] scenes;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		int selection = -1;
		if (Input.GetKey("1")) selection = 0;
		if (Input.GetKey("2")) selection = 1;
		if (Input.GetKey("3")) selection = 2;
		if (selection != -1) {
			Debug.Log(selection);
			bool active;
			for(int i=0; i<scenes.Length; i+=1) {
				active = (i == selection);
				scenes[i].SetActive(active);
				Debug.Log(active);
			}
		}
	}
}
