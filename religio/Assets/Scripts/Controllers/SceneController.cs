using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class SceneController : MonoBehaviour {

	public int dayScene = 1;

	SceneController(){
	}

	public void ShowNight() {
		//TODO switch the scene view
	}

	public void ShowDay() { 
		//TODO switch the scene view
		SceneManager.LoadScene(dayScene);
	}
}
