using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetLosingText : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		int score = PlayerPrefs.GetInt("score");
		if (score == 0) {
			GetComponent<Text>().text = "You got caught, and you didn't even get your WKD! FAILURE!";
		} else {
			GetComponent<Text>().text = "It cost you £" + score + ", you got caught, and you didn't even get your WKD";
		}
	}
}
