using UnityEngine;
using System.Collections;
using Spine;

public class LeanArms : MonoBehaviour {

	public LocatorController controller;
	public LocatorController legsController;

	void Update () {
		SkeletonAnimation skeletonAnimation = GetComponent<SkeletonAnimation>();
		Bone torso = skeletonAnimation.skeleton.FindBone("torso");
		if (legsController.horizontalMovement < 0) {
			torso.rotation =  (float)(90 + controller.horizontalMovement * 0.5);
		} else {
			torso.rotation =  (float)(90 - controller.horizontalMovement * 0.5);
		}
	}
}
