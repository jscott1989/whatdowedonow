using UnityEngine;
using System.Collections;

public class ScoreOnCollide : MonoBehaviour {
	bool hasCollided = false;

	void OnCollisionEnter (Collision c) {
		if (!hasCollided) {
			hasCollided = true;
			GameObject.FindObjectOfType<Score>().score += 10;
		}
	}
}
