using UnityEngine;
using UnityEngine.UI;
using Rand = System.Random;
using System.Collections.Generic;
using System;
using System.IO;

public class City : Organization {

	public int population;
		
	public void Start() {

		// Sets up stance
		Randomize ();

		population = UnityEngine.Random.Range(10000, 200000);

		// Sets city name
		name = StringListReader.GetRandom ("CityNames");
		gameObject.GetComponentInChildren<Text>().text = name;

	}
}