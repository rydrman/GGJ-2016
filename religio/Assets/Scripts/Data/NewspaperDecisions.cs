using System;
using System.Linq;
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
		return allDecisions [UnityEngine.Random.Range(0, allDecisions.Count)];
	}
	static public DecisionDefinition GetRandomForTopic(Topic topic) {
		Load ();
		List<DecisionDefinition> options = allDecisions.Where( d => d.topic == topic ).ToList();
		if(options.Count == 0) {
			return null;
		}
		return options [UnityEngine.Random.Range(0, options.Count)];
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
					d.options[i].description = def[4 + i].Substring( 0, def[4+i].Length - parts[parts.Length-1].Length-1 );
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
