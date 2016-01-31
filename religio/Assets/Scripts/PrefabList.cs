using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[System.Serializable]
public class PrefabList : MonoBehaviour {
	public GameObject newspaper;
	public GameObject docet;
	public GameObject memo;

	public string decisionBasePath = "Data/Decisions";
	public string paperDecisionPrefabPath = "Newspaper";
	public List<NewspaperDecision> paperDecisions;

	public void Start() {
		string[] assetsPaths = AssetDatabase.GetAllAssetPaths ();

		foreach (string assetPath in assetsPaths) {
			//see if its a decision
			if (assetPath.Contains (decisionBasePath)) {
				//check for newspaper
				if (assetPath.Contains (paperDecisionPrefabPath) &&
					assetPath.Contains (".prefab")) {
					Debug.Log(assetPath);
					GameObject obj = AssetDatabase.LoadAssetAtPath<GameObject> (assetPath);
					NewspaperDecision decision = obj.GetComponent<NewspaperDecision> ();
					paperDecisions.Add (decision);
				}   
			}
		}
	}
}