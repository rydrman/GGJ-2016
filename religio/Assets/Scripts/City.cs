using UnityEngine;
using Rand = System.Random;
using System.Collections.Generic;
using System;
using System.IO;

public class City : Organization {
		
	public void Start() {
		name = StringListReader.GetRandom ("CityNames");
		Randomize ();
	}
}