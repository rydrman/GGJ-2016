using System;
using System.IO;
using System.Collections.Generic;

using Rand = System.Random;

public class CityNameList {

	static List<string> NAMES = new List<string>();
	static Rand RAND = new Rand ((int)DateTime.Now.Ticks);

	static void EnsureLoaded() {
		if(NAMES.Count == 0) {
			NAMES.AddRange (File.ReadAllLines ("./Assets/Data/CityNames.txt"));
		}
	}

	public static string GetName() {
		EnsureLoaded ();
		int sel = RAND.Next (NAMES.Count);
		string name = NAMES[sel];
		NAMES.RemoveAt (sel);
		return name;
	}
}
