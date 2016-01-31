using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class NewspaperDecision : Decision {



	public override void Define(DecisionDefinition def, Dictionary<string, string> values) {
		base.Define (def, values);
		UpdateUI();
	}

	public void UpdateUI () {
		Document doc = GetComponent<Document> ();
		//doc.SetBody (m_body);
		doc.SetTitle (definition.title);
	}
}
