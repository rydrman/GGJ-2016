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

	public static string ToString(Topic topic){
		switch(topic) {
		case Topic.Business:
			return "Business";
		case Topic.Culture: 
			return "Culture";
		case Topic.Diplomacy:
			return "Diplomacy";
		case Topic.Education:
			return "Education";
		case Topic.Freedom:
			return "Freedom";
		case Topic.Welfare:
			return "Welfare";
		default:
			return "default TopicUtil.ToString";
		}
		
	}

	public static Topic Random() {
		float val = UnityEngine.Random.value;
		if(val < 1 / 6f) {
			return Topic.Business;
		}
		else if(val < 2 / 6f) {
			return Topic.Culture;
		}
		else if(val < 3 / 6f) {
			return Topic.Diplomacy;
		}
		else if (val < 4 / 6f) {
			return Topic.Education;
		}
		else if(val < 5 / 6f) {
			return Topic.Freedom;
		}
		return Topic.Welfare;
	}
}
