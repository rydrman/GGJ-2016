using System;
using System.IO;
using System.Collections.Generic;

public static class DecisionReader {
	public static List<List<string>> ReadFile(string filePath) {
		List<List<string>> decisions = new List<List<string>> ();

		StreamReader fstream = new StreamReader(filePath);
		string line = null;
		List<string> lines = new List<string> ();
		// do each line on the file
		while((line = fstream.ReadLine()) != null) {

			if (line[0] == '#') {
				if(0 != lines.Count) {
					decisions.Add (lines);
					lines = new List<string> ();
				}
				continue;
			}
			lines.Add (line);
		}

		return decisions;
	}
}



