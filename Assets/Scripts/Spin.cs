using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour {

	public float spinx = 0;
	public float spiny = 0;
	public float spinz = 0;

	// Update is called once per frame
	void Update () {
		transform.Rotate (spinx * Time.deltaTime, spiny * Time.deltaTime, spinz * Time.deltaTime);
	}
}
