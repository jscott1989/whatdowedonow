using UnityEngine;
using System.Collections;

public class GoToScene2 : MonoBehaviour {
	public void Update() {
		if (Input.GetKeyDown ("space")) {
			Application.LoadLevel (1);
		}
	}
}
