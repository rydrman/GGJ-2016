using System;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Organization : MonoBehaviour
{
	
	Dictionary<Topic, int> m_stances;

	public Organization ()
	{
		Topic[] topics = Topic.GetValues (Topic);
		foreach(Topic t in topics) {
			m_stances [t] = 0;
		}
	}

	public int GetStance(Topic topic) {
		return m_stances [topic];
	}

	public void SetStance(Topic topic, int value) {
		m_stances [topic] = Math.Min(100, Math.Max(-100, value));
	}

	public int ChangeStance(Topic topic, int delta) {
		int value = GetStance (topic) + delta;
		SetStance (topic, value);
		return value;
	}
}


