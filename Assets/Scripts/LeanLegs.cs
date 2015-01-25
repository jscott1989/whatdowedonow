using UnityEngine;
using System.Collections;
using Spine;

public class LeanLegs : MonoBehaviour {
	
	public LocatorController controller;
	
	void Update () {
		SkeletonAnimation skeletonAnimation = GetComponent<SkeletonAnimation>();
		Bone torso = skeletonAnimation.skeleton.FindBone("torso");
//		torso.rotation = 90 + controller.horizontalMovement;
	}
}
