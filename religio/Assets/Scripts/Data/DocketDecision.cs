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

	public GameObject dialogPrefab;
	public GameObject characterPrefab;
	public Button accept;

	GameObject dialog;
	GameObject character;


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
		//put away the docet
		ObjectInteraction interaction = GetComponent<ObjectInteraction> ();
		interaction.Defocus ();

		//create a character thing
		character = Instantiate (characterPrefab);
		character.transform.position = GameObject.Find("CharacterRoot").transform.position;
		character.transform.rotation = GameObject.Find("CharacterRoot").transform.rotation;
		character.transform.localScale = GameObject.Find("CharacterRoot").transform.localScale;
		character.GetComponent<ReligioCharacter>().Enter();
		dialog = Instantiate (dialogPrefab);
		dialog.GetComponent<Document> ().SetBody (definition.title);
		Button[] buttons = dialog.GetComponentsInChildren<Button> ();
		if(buttons.Count() != 3) {
			Debug.Log ("Why are there not 3 buttons on docet dialog children?");
		}

		buttons[0].gameObject.GetComponentInChildren<Text> ().text = definition.options[0].description;
		buttons[0].onClick.AddListener (() => ButtonClicked (0));
		buttons[1].gameObject.GetComponentInChildren<Text> ().text = definition.options[1].description;
		buttons[1].onClick.AddListener (() => ButtonClicked (1));
		buttons[2].gameObject.GetComponentInChildren<Text> ().text = definition.options[2].description;
		buttons[2].onClick.AddListener (() => ButtonClicked (2));
	}

	public void CharacterLeave() {
		//TODO make character leave and destroy when finished
		character.GetComponent<ReligioCharacter>().CompleteInteraction();
	}

	public void ButtonClicked(int index) {
		Destroy (dialog);
		CharacterLeave ();
		choice = definition.options [index];
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