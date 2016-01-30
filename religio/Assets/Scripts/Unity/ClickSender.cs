using UnityEngine;
using System.Collections;

public class ClickSender : MonoBehaviour {

	ObjectInteraction m_interactions;

	public bool k_negate = false;
	public GameObject m_target;

	void Reset () {
		m_interactions = m_target.GetComponent<ObjectInteraction>();
	}

	void OnMouseDown () {
		if (k_negate)
			m_interactions.Focus();
		else
			m_interactions.Defocus();
	}
}
