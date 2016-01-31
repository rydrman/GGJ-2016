using UnityEngine;
using System.Collections;

public class PersistOnLoad : MonoBehaviour {
	void Awake() {
        DontDestroyOnLoad(transform.gameObject);
        Debug.Log("Not destroying");
    }
}
