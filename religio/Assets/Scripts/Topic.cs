using System;
using UnityEngine;

[System.Serializable]
public class Topic : MonoBehaviour {

	static uint next_uid = 0;

	uint m_uid;
	int m_value = 0;

	Topic() {
		m_uid = next_uid++;
		value = 0;
	}

	public uint uid {
		get {
			return m_uid;
		}
	}

	public int value { 
		get {
			return m_value;
		}
		set {
			m_value = Math.Max (-100, Math.Min (100, value));
		}
	}

}
