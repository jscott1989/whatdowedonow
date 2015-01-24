using UnityEngine;
using System.Collections;

public class SimpleMovementController : MonoBehaviour {

	static float speed = 1;

	bool dead = false;

	void Update () {
		SkeletonAnimation s = this.GetComponent<SkeletonAnimation>();
		if (!dead) {
			if (Input.GetKey ("left")) {
				transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
				s.state.SetAnimation(0, "walk", true);
			} else if (Input.GetKey ("right")) {
				transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
				s.state.SetAnimation(0, "walk", true);
			} else if (Input.GetKey ("up")) {
				transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed * Time.deltaTime);
				s.state.SetAnimation(0, "walk", true);
			} else if (Input.GetKey ("down")) {
				transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed * Time.deltaTime);
				s.state.SetAnimation(0, "walk", true);
			} else if (Input.GetKey ("f")) {
				s.state.SetAnimation(0, "death", false);
				dead = true;
			} else {
				s.state.ClearTracks();
			}
		}

	}
}
