using UnityEngine;

[System.Serializable]
public class NewspaperDecision : Decision {

	public string m_body;
	public string body { 
		get {
			return m_body;
		}
		set {
			m_body = value;
			UpdateUI ();
		}
	}

	new public string title {
		get {
			return base.title;
		}
		set {
			base.title = value;
			UpdateUI ();
		}
	}

	public void Copy(NewspaperDecision source) {

		title = source.title;
		body = source.body;

		base.Copy(source);
	}

	public void UpdateUI () {
		Document doc = GetComponent<Document> ();
		doc.SetBody (m_body);
		doc.SetTitle (title);
	}
}
