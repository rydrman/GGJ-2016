using System;

public class Topic {

	static uint next_uid = 0;

	uint m_uid;
	string m_name;
	int m_value = 0;

	Topic(string name) {
		m_uid = next_uid++;
		m_name = name;
		value = 0;
	}

	public string name {
		get {
			return m_name;
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
