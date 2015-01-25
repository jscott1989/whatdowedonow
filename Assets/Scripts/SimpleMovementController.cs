using UnityEngine;
using System.Collections;

public class SimpleMovementController : MonoBehaviour {
	static float speed = 0.2f;

	public Transform arms;

	public LocatorController locator;

	void Update () {
		SkeletonAnimation s = this.GetComponent<SkeletonAnimation>();
		SkeletonAnimation s2 = arms.GetComponent<SkeletonAnimation>();
		CharacterController cc = this.GetComponent<CharacterController>();

		bool moved = false;

		cc.Move (new Vector3(locator.horizontalMovement * speed*Time.deltaTime,0,locator.verticalMovement * speed * Time.deltaTime));

		if (locator.horizontalMovement != 0 || locator.verticalMovement != 0) {
			s.state.SetAnimation(0, "walk", true);
			moved = true;
		}

		if (locator.horizontalMovement < 0) {
			transform.localScale = new Vector3(-0.7f, transform.localScale.y, transform.localScale.z);
		} else {
			transform.localScale = new Vector3(0.7f, transform.localScale.y, transform.localScale.z);
		}

	
		if (!moved) {
			s.state.ClearTracks();
		}
	}
}
