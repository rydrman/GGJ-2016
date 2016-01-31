using UnityEngine;
using System.Collections;

public class CityController : MonoBehaviour {

	public GameState gameSate;

	GameObject cityMenu;
	MapCameraController mapCamera;
	Vector3 cameraTargetPosition;

	// Use this for initialization
	void Start () {
		cityMenu = GameObject.Find("CityMenu");
		mapCamera = Camera.main.GetComponent<MapCameraController> ();
		cameraTargetPosition = new Vector3 (gameObject.transform.position.x, Camera.main.transform.position.y, gameObject.transform.position.z-30);
	}

	void OnMouseDown () {

		// Display the city menu over the city
		cityMenu.GetComponent<CityMenuController>().ToggleVisibility (true);
		cityMenu.transform.position = new Vector3 (transform.position.x - (cityMenu.GetComponent<Collider>().bounds.size.x / 2), cityMenu.transform.position.y, transform.position.z+5);

		// Move the camera in on the city
		mapCamera.TriggerMove (cameraTargetPosition);
		mapCamera.TriggerZoom (mapCamera.minZoom);

		// Fade out other city names for dramatic effect
		foreach (GameObject go in GameObject.FindGameObjectsWithTag("CityName")) {
			go.GetComponent<CanvasGroup> ().alpha = 0.5f;
		}
		gameObject.GetComponentInChildren<CanvasGroup> ().alpha = 1.0f;
	}
}
