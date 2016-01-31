using UnityEngine;
using System.Collections;

public class ReligioCharacter : MonoBehaviour {

	public int direction = 0;
	public Animator m_anim;
	public Animator root_anim;

	public void Start() {
		m_anim = GetComponent<Animator>();
		root_anim = transform.Find("Root").GetComponent<Animator>();
		m_anim.SetTrigger("enter");
		MoveRight();
	}

	public void CompleteInteraction() {
		Debug.Log("Interacted");
		m_anim.SetTrigger("interacted");
	}

	public void RandomizeCharacter() {
		foreach(FeatureSelector feature in
				GetComponentsInChildren<FeatureSelector>()) {
			feature.SelectRandomFeature();  // FIXME: .Randomize()
		}
	}

	public void Update() {
		root_anim.SetInteger("direction", direction);
	}

	public void MoveRight() { direction = 1; }
	public void StopMoving() { direction = 0; }
	public void Enter() { m_anim.SetTrigger("enter"); }

	void OnMouseDown() {
		Debug.Log("Clicked");
		CompleteInteraction();
	}
}