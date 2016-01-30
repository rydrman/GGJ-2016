using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
class Decision : MonoBehaviour {

	public List<DecisionOption> options;

	string m_title;
	DecisionOption m_choice;

	public Decision( ) {
		options = new List<DecisionOption> ();
	}

	public DecisionOption choice{ 
		get {
			return m_choice;
		}
	}

	public void MakeDecision(DecisionOption option) {
		if (!options.Contains(option)) {
			return;
		}
		m_choice = option;
	}

}
