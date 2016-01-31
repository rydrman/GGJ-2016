using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class DecisionOption : MonoBehaviour
{
	public string description;
	public DictionaryTopicInt effect;

	public DecisionOption()
	{
		effect = new DictionaryTopicInt();
		foreach(Topic t in Enum.GetValues(typeof(Topic))){
			effect[t] = 0;
		}
	}
}
