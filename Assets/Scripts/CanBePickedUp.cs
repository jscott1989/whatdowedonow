using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanBePickedUp : MonoBehaviour {

	public Image WKDImage;
	public Transform WKDBig;

	bool gotWKD = false;
	
	void Update() {
		if (!gotWKD && transform.position.x > 42.8) {
			WKDImage.enabled = true;
			GameObject.Destroy (WKDBig.gameObject);
			gotWKD = true;
		} else if (gotWKD && transform.position.x < -44) {
			Debug.Log("WIN");
		}
	}
}
