﻿using UnityEngine;
using System.Collections;

public class StopFlying : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y > 0.1246) {
			transform.position = new Vector3(transform.position.x, 0.1246f, transform.position.z);
		}
	}
}
