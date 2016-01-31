using System;
using System.IO;
using System.Collections.Generic;

using Rand = System.Random;

public static class StringListReader {

	static Dictionary<string, string[]> files = new Dictionary<string, string[]>();

	static List<string> NAMES = new List<string>();
	static Rand RAND = new Rand ((int)DateTime.Now.Ticks);

	static string[] Load(string file) {
		if(!files.ContainsKey(file)) {
			try {
				files [file] = File.ReadAllLines ("./Assets/Data/" + file + ".txt");
			}
			catch {
				files[file] = new string[1]{"!" + file};
			}
		}
		return files [file];
	}

	public static string GetRandom(string type) {
		string[] options = Load (type);
		return options[RAND.Next (options.Length)];
	}
}
