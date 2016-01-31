using System;
using UnityEngine;
using System.Collections.Generic;

public class DecisionDefinition {
	public string title;
	public int minLevel;
	public int maxLevel;
	public Topic topic;
	public DecisionOption[] options;
}

[System.Serializable]
public class Decision : MonoBehaviour {

	public DecisionDefinition definition;
	public DecisionOption m_choice;

	public virtual void Define(DecisionDefinition def, Dictionary<string, string> values) {
		definition = def;
		CompileDefitionTitle (values);
	}

	public void CompileDefitionTitle(Dictionary<string, string> values){
		definition.title = FormatStringWithDict (definition.title, values);
	}

	public static string FormatStringWithDict(string source, Dictionary<string, string> values) {
		List<string> parts = new List<string> ();
		parts.AddRange (source.Split ('['));
		for(int i = 0; i < parts.Count; ++i) {
			//if it has a closing bracket there is a var here
			if (parts[i].Contains ("]")) {
				string[] splt = parts [i].Split(']');

				//try to find the variable in the dictionary
				if (values.ContainsKey(splt[0])) {
					parts [i] = values [splt [0]];
				}
				//then try to see if we have  file to load from
				else {
					parts [i] = StringListReader.GetRandom (splt [0]);
				}
				parts.Insert(i+1, splt [1]);
				i++;
			}
		}
		source = "";
		foreach(string part in parts) {
			source += part;
		}
		return source;
	}

	public DecisionOption choice{ 
		get {
			return m_choice;
		}
		set {
			if (-1 == Array.IndexOf (definition.options, value)) {
				return;
			}
			m_choice = value;
		}
	}
}