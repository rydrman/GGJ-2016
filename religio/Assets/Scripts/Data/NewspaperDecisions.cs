using System;
using UnityEngine;
using System.Collections.Generic;

public static class NewspaperDecisions {

	static List<DecisionDefinition> allDecisions = new List<DecisionDefinition>();

	static public List<DecisionDefinition> GetAll() {
		Load ();
		return allDecisions;
	}

	static public DecisionDefinition GetRandom() {
		Load ();
		System.Random rand = new System.Random ((int)DateTime.Now.Ticks);
		return allDecisions [rand.Next (allDecisions.Count)];
	}

	static void Load() {
		if(0 != allDecisions.Count) {
			return;
		}

		//we haven't loaded, read the file
		List<List<string>> defs = DecisionReader.ReadFile ("./Assets/Data/Decisions/Newspaper.txt");

		foreach(List<string> def in defs) {
			//has to be the right number of lines
			if(def.Count != 7) {
				Debug.Log ("Rejecting Newspaper Decision, not enough lines: " + def [0]);
				continue;
			}
			try {
				DecisionDefinition d = new DecisionDefinition();
				d.title = def[0];
				d.topic = TopicUtil.MapTopic(def[1]);
				d.minLevel = Int32.Parse(def[2]);
				d.maxLevel = Int32.Parse(def[3]);
				d.options = new DecisionOption[3];
				for(int i = 0; i < 3; ++i)
				{
					d.options[i] = new DecisionOption();
					string[] parts = def[4 + i].Split(' ');
					d.options[i].description = def[4 + i].Substring( def[4+i].Length - parts[parts.Length-1].Length );
					d.options[i].value = Int32.Parse(parts[parts.Length-1]);
				}
				allDecisions.Add(d);
			}
			catch(Exception e) {
				Debug.Log ("Rejecting Newspaper Decision, invalid: " + def [0]);
				Debug.Log (e.Message);
				Debug.Log ((new System.Diagnostics.StackTrace(e, true)).ToString());
				continue;
			}
		}
	}
	
}
