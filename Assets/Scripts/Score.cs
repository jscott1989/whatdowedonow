using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	public int score;

	// Update is called once per frame
	void Update () {
		Text text = GetComponent<Text>();
		text.text = "£" + score + " Total Cost";
	}
}
