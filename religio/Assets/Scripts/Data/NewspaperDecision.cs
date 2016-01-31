using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

[System.Serializable]
public class NewspaperDecision : Decision {

	public Button button1;
	public Text option1;
	public Button button2;
	public Text option2;
	public Button button3;
	public Text option3;

	public void Start() {
		button1.onClick.AddListener(() => Button1Clicked());
		button2.onClick.AddListener(() => Button2Clicked());
		button3.onClick.AddListener(() => Button3Clicked());
	}

	public void UnselectButtons() {
		button1.interactable = true;
		button2.interactable = true;
		button3.interactable = true;
	}

	public void Button1Clicked() {
		UnselectButtons ();
		button1.interactable = false;
		choice = definition.options [0];
	}

	public void Button2Clicked() {
		UnselectButtons ();
		button2.interactable = false;
		choice = definition.options [1];
	}

	public void Button3Clicked() {
		UnselectButtons ();
		button3.interactable = false;
		choice = definition.options [2];
	}

	public override void Define(DecisionDefinition def, Dictionary<string, string> values) {
		base.Define (def, values);
		UpdateUI();
	}

	public void UpdateUI () {
		Document doc = GetComponent<Document> ();
		option1.text = definition.options [0].description;
		option2.text = definition.options [1].description;
		option3.text = definition.options [2].description;
		doc.SetTitle (definition.title);
	}
}
