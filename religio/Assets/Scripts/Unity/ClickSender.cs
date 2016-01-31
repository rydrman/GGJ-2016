using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class ClickSender : MonoBehaviour {

	ObjectInteraction m_interactions;

	RaycastHit hit;
  Ray ray;

	// private const float k_debounce = 1000 / 16.0f;
	// private float m_delay = 0.0f;

	// public bool k_negate = false;
	public bool m_clickedon = false;
	public GameObject m_target;

	void Reset () {
		m_interactions = m_target.GetComponent<ObjectInteraction>();
		// m_delay = 0.0f;
	}

	void Start() {
		Reset();
	}

	void Update() {
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Input.GetMouseButtonDown(0)) {
			bool reference = m_clickedon;
			m_clickedon = false;
			Physics.Raycast(ray, out hit, Mathf.Infinity);
			foreach (Collider collider in m_interactions.Colliders()) {
				if (hit.collider == collider) {
					m_clickedon = true;
					m_interactions.Focus();
				}
			}
			if (reference && !m_clickedon) {
				m_interactions.Defocus();
			}
		}
	}
}
		// if (m_clickedon && m_delay < 0.0f) {
		// 	m_clickedon = false;
		// 	m_delay = 0.0f;
		// } else {
		// 	m_delay -= Time.deltaTime;
		// }
		// // if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverEventSystemObject()) {
		// if (Input.GetMouseButtonDown(0)) {
		// 	bool touched = false;
		// 	Physics.Raycast(ray, out hit, Mathf.Infinity);
		// 	foreach (Collider collider in m_interactions.Colliders()) {
		// 		if (hit.collider == collider) {
		// 			touched = true;
		// 			m_delay = k_debounce;
		// 		}
		// 	}
		// 	if (!k_negate && !touched)
		// 		m_interactions.Defocus();
		// }

		// }
	// }

// 	void OnMouseDown () {
// 		if (k_negate)
// 			m_interactions.Defocus();
// 		else
// 			m_interactions.Focus();
// 	}
// }
