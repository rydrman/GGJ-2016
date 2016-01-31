using UnityEngine;
using Rand = System.Random;
using System.Collections.Generic;
using System;
using System.IO;

public class City : Organization {

	public int population = UnityEngine.Random.Range(10000, 200000);
		
	public void Start() {
		name = StringListReader.GetRandom ("CityNames");
		Randomize ();
	}
}