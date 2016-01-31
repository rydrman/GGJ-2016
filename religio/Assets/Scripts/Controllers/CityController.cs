using UnityEngine;
using System.Collections;

public class CityController : MonoBehaviour {

	GameObject cityMenu;
	MapCameraController mapCamera;
	Vector3 cameraTargetPosition;

	// Use this for initialization
	void Start () {
		cityMenu = GameObject.Find("CityMenu");
		mapCamera = Camera.main.GetComponent<MapCameraController> ();
		cameraTargetPosition = new Vector3 (gameObject.transform.position.x, Camera.main.transform.position.y, gameObject.transform.position.z-30);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown () {
		cityMenu.GetComponent<CityMenuController>().ToggleVisibility (true);
		cityMenu.transform.position = new Vector3 (transform.position.x - (cityMenu.GetComponent<Collider>().bounds.size.x / 2), cityMenu.transform.position.y, transform.position.z);
		mapCamera.TriggerMove (cameraTargetPosition);
		mapCamera.TriggerZoom (mapCamera.minZoom);
	}
}
