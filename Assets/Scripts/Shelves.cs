using UnityEngine;
using System.Collections;

public class Shelves : MonoBehaviour {

	void OnCollisionEnter(Collision c) {
		if (c.gameObject.tag == "WillNotPush") {
			return;
		}
		foreach (Transform child in transform){
			foreach (Transform child2 in child){
				Debug.Log (child2.gameObject.tag);
				if(child2.gameObject.tag == "Fallable"){
					child2.rigidbody.isKinematic = false;
				}
			}
		}
	}
}