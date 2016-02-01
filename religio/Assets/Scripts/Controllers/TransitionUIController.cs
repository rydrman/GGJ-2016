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
		GetComponent<SoundSampler>().PlaySound();
	}

	public void ShowEndDay() {
		InactiveAll();
		endDayCanvas.SetActive(true);
		GetComponent<SoundSampler>().PlaySound();
	}

	public void ShowNextButton() {
		InactiveAll();
		nextDayButton.SetActive(true);
	}
}