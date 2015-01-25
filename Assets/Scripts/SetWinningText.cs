using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetWinningText : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Text>().text = "You got your WKD to share. And it only cost £" + PlayerPrefs.GetInt("score");
	}
}
