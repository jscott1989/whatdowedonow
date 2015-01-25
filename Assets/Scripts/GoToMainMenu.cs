using UnityEngine;
using System.Collections;

public class GoToMainMenu : MonoBehaviour {
	public void Update() {
		if (Input.GetKeyDown ("space")) {
			Application.LoadLevel (0);
		}
	}
}
