using UnityEngine;
using System.Collections;

/**
 * Make the camera follow the character around the scene
 */
public class FollowCharacter : MonoBehaviour {

	public Transform target;

	void LateUpdate () {
		transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
	}
}
