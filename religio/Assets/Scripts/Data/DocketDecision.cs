using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;

public class DocketDecisionDefinition : DecisionDefinition {
	public Organization org;
	public char personType;
	public string name;
}

public class DocketDecision : Decision {

	public GameObject dialog;
	public GameObject personPrefab;
	public Button accept;

	new public DocketDecisionDefinition definition {
		get {
			return (DocketDecisionDefinition)base.definition;
		}
	}

	public void Start() {
		accept.onClick.AddListener (() => acceptClick ());
	}

	void acceptClick() {
		accept.interactable = false;
		//TODO open stuff and people stuff
	}
		
	public void Define(DocketDecisionDefinition def, Dictionary<string, string> values) {
		base.Define (def, values);
		GenerateProfile();
	}

	public void GenerateProfile () {
		Document doc = GetComponent<Document> ();
		definition.name = StringListReader.GetRandom ("PersonName");
		doc.SetTitle (definition.name);
		List<string> attribs = new List<string> ();
		attribs.Add("Representing: " + definition.org.name);
		attribs.Add("Eye Color: " + StringListReader.GetRandom("Color"));
		attribs.Add("Hair Color: " + StringListReader.GetRandom("Color"));
		attribs.OrderBy<string, float> ((string item) => UnityEngine.Random.value);
		string body = "";
		foreach(string attrib in attribs) {
			body += attrib + "\n";
		}
		doc.SetBody (body);
	}
}