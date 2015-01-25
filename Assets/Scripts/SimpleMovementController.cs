using UnityEngine;
using System.Collections;

public class SimpleMovementController : MonoBehaviour {
	static float speed = 5;

	bool dead = false;

	bool movingRight = true;

	public Transform arms;

	void Update () {
		SkeletonAnimation s = this.GetComponent<SkeletonAnimation>();
		SkeletonAnimation s2 = arms.GetComponent<SkeletonAnimation>();
		CharacterController cc = this.GetComponent<CharacterController>();

		if (!dead) {
			bool moved = false;
			if (Input.GetKey ("left")) {
				cc.Move (new Vector3(-speed*Time.deltaTime,0,0));
				s.state.SetAnimation(0, "walk", true);
				moved = true;

				movingRight = false;

				transform.localScale = new Vector3(-0.7f, transform.localScale.y, transform.localScale.z);
			}
			if (Input.GetKey ("right")) {
				cc.Move (new Vector3(speed*Time.deltaTime,0,0));
				s.state.SetAnimation(0, "walk", true);
				moved = true;

				movingRight = true;
				transform.localScale = new Vector3(0.7f, transform.localScale.y, transform.localScale.z);
			}
			if (Input.GetKey ("up")) {
				cc.Move (new Vector3(0,0,speed*Time.deltaTime));
				s.state.SetAnimation(0, "walk", true);
				moved = true;
			}
			if (Input.GetKey ("down")) {
				cc.Move (new Vector3(0,0,-speed*Time.deltaTime));
				s.state.SetAnimation(0, "walk", true);
				moved = true;
			}
			if (Input.GetKey ("f")) {
				s.state.SetAnimation(0, "death", false);
				s2.state.SetAnimation(0, "death", false);
				dead = true;
				moved = true;
			}

			if (!moved) {
				s.state.ClearTracks();
			}
		}
	}
}
