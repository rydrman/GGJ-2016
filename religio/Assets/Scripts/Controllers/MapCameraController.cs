﻿using UnityEngine;
using System;
using System.Collections;

[Serializable]
public class MapCameraController : MonoBehaviour {

	public float moveStep = 1.5f;
	public float moveVel = 1.0f;
	private Vector3 targetPosition;

	public float minZoom = 50.0f;
	public float maxZoom = 80.0f;
	public float zoomStep = 3.0f;
	public float zoomVel = 1.0f;
	public float zoomDamp = 0.5f;
	private float targetZoom;

	// Use this for initialization
	void Start () {
	
		targetZoom = (maxZoom + minZoom) / 2.0f;
		targetPosition = transform.position;

	}
	
	// Update is called once per frame
	void Update () {
		InputControls ();
	}

	void FixedUpdate () {
		
	}

	void InputControls () {

		// Zoom in and out
		targetZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomStep;
		targetZoom = Mathf.Clamp(targetZoom, minZoom, maxZoom);
		TriggerZoom (targetZoom);

		// Move Left and Right
		if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
			targetPosition.x += moveStep;
		}
		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
			targetPosition.x -= moveStep;
		}
		if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)){
			targetPosition.z += moveStep;
		}
		if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) {
			targetPosition.z -= moveStep;
		}
		TriggerMove (targetPosition);

	}

	public void TriggerZoom( float target ) {
		Camera.main.fieldOfView = Mathf.SmoothDamp(Camera.main.fieldOfView, target, ref zoomVel, zoomDamp);
		targetZoom = target;
	}

	public void TriggerMove( Vector3 target ) {
		Camera.main.transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * moveVel);
		targetPosition = target;
	}
}
