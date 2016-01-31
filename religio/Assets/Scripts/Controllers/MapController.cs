using UnityEngine;
using System.Collections;

public class MapController : MonoBehaviour {

	GameObject cityMenu;
	MapCameraController mapCamera;

	// Use this for initialization
	void Start () {
		cityMenu = GameObject.Find ("CityMenu");
		mapCamera = Camera.main.GetComponent<MapCameraController> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown () {
		cityMenu.GetComponent<CityMenuController>().ToggleVisibility (false);
		mapCamera.TriggerZoom (mapCamera.maxZoom);
	}
}
