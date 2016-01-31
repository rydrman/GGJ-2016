using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
	
	public int m_scene;

	public void SetScene(UnityEngine.UI.Dropdown dropdown) {
		m_scene = dropdown.value;
		Debug.Log(m_scene);
	}

	public void LoadScene() {
		Debug.Log("Loading...");
		SceneManager.LoadScene(m_scene);
	}
}
