using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
class TransitionUIController : MonoBehaviour {

	public GameObject endDayCanvas;
	public GameObject startDayCanvas;
	public GameObject nextDayButton;

	public void Start() {
		InactiveAll ();
	}

	public void InactiveAll() {
		endDayCanvas.SetActive (false);
		startDayCanvas.SetActive (false);
		nextDayButton.SetActive (false);
	}

	public void ShowStartDay() {
		InactiveAll();
		startDayCanvas.SetActive(true);
	}

	public void ShowEndDay() {
		InactiveAll();
		endDayCanvas.SetActive(true);
	}

	public void ShowNextButton() {
		InactiveAll();
		nextDayButton.SetActive(true);
	}
}