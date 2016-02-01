using UnityEngine;
using System.Collections.Generic;

public class DayController : MonoBehaviour {

	public Transform newspaperRoot;
	public Vector3 newspaperDelta;
	public Transform docetRoot;
	public Vector3 docetDelta;
	public Transform memoRoot;
	public Vector3 memoDelta;

	public DecisionSet decisionSet { get; private set; }

	DayController() {
	}

	public void Update() {
		// GameObject tmp = GameObject.Find("NewspaperRoot");
		// Debug.Log(tmp);
	}

	public void Populate(DecisionSet decisions) {

		Debug.Log("Populating...");

		decisionSet = decisions;

		if (null == newspaperRoot) {
			newspaperRoot = GameObject.Find ("NewspaperRoot").transform;
		}
		Vector3 d = newspaperDelta;
		foreach( GameObject paper in decisions.newspapers ) {
			paper.transform.SetParent (newspaperRoot);
			paper.transform.position = newspaperRoot.position;
			paper.transform.localRotation = newspaperRoot.localRotation;
			paper.transform.localScale = newspaperRoot.localScale;
			paper.transform.position += d;
			d += newspaperDelta;
		}

		if (null == memoRoot) {
			memoRoot = GameObject.Find ("MemoRoot").transform;
		}
		d = memoDelta;
		foreach( GameObject memo in decisions.memos ) {
			memo.transform.SetParent (memoRoot);
			memo.transform.position = memoRoot.position;
			memo.transform.position += d;
			d += memoDelta;
		}

		if (null == docetRoot) {
			docetRoot = GameObject.Find ("DocetRoot").transform;
		}
		d = docetDelta;
		foreach( GameObject docet in decisions.docets ) {
			docet.transform.SetParent (docetRoot);
			docet.transform.position = docetRoot.position;
			docet.transform.localRotation = docetRoot.localRotation;
			docet.transform.localScale = docetRoot.localScale;
			docet.transform.position += d;
			d += docetDelta;
		}
	}
}
