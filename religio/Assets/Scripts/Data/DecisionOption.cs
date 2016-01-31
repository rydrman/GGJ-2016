using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DecisionOption : MonoBehaviour
{
	public string description;
	public Dictionary<Topic, int> effect;
}

