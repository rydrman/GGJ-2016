using System;
using UnityEngine;

[System.Serializable]
public class Decision : MonoBehaviour {

	public DecisionOption[] options = new DecisionOption[3];

	string m_title;
	DecisionOption m_choice;

	public Decision( ) {
	}

	public DecisionOption choice{ 
		get {
			return m_choice;
		}
	}

	public void Copy(Decision source) {
		m_title = source.m_title;
		options = source.options;
	}

	public void MakeDecision(DecisionOption option) {
		if (-1 == Array.IndexOf(options, option)) {
			return;
		}
		m_choice = option;
	}

}
