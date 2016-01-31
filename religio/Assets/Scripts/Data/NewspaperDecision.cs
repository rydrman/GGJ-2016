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
