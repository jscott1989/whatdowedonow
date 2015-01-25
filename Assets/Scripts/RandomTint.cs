using UnityEngine;
using System.Collections;

public class RandomTint : MonoBehaviour {

	// Use this for initialization
	void Start () {
		renderer.material.color = new Color(Random.Range(0.0f,1.0f),Random.Range(0.0f,1.0f),Random.Range(0.0f,1.0f));
	}
}
