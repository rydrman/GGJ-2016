using System;
using UnityEngine;

[System.Serializable]
public enum Topic{
	Education,
	Culture,
	Diplomacy,
	Business,
	Freedom,
	Welfare
}

public static class TopicUtil {
	public static Topic MapTopic(string letter) {
		switch(letter[0]) {
			case 'E':
				return Topic.Education;
			case 'C':
				return Topic.Culture;
			case 'D':
				return Topic.Diplomacy;
			case 'B':
				return Topic.Business;
			case 'F':
				return Topic.Freedom;
			case 'W':
				return Topic.Welfare;
			default:
				return Topic.Education;
		}
	}
}
