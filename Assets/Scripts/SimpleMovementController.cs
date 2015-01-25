using UnityEngine;
using System.Collections;

public class SimpleMovementController : MonoBehaviour {
	static float speed = 0.2f;

	public Transform arms;

	public LocatorController locator;
	public LocatorController locator2;

	public float locator1Amount;
	public float locator2Amount;

	public Transform trenchcoat;

	bool dead;

	void Start() {
		SkeletonAnimation s = this.GetComponent<SkeletonAnimation>();
		s.state.SetAnimation(0, "walk", true);
		s.state.ClearTracks();
	}

	void Update () {
		if (!dead) {
			SkeletonAnimation s = this.GetComponent<SkeletonAnimation>();
			SkeletonAnimation s2 = arms.GetComponent<SkeletonAnimation>();
			CharacterController cc = this.GetComponent<CharacterController>();

			bool moved = false;

			cc.Move (new Vector3((locator.horizontalMovement * speed*Time.deltaTime * locator1Amount) + (locator2.horizontalMovement * speed*Time.deltaTime * locator2Amount),0,(locator.verticalMovement * speed * Time.deltaTime * locator1Amount)+(locator2.verticalMovement * speed * Time.deltaTime * locator2Amount)));

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

			if (Mathf.Abs(locator.horizontalMovement) == 50 || Mathf.Abs (locator.verticalMovement) == 50) {
				dead = true;

				trenchcoat.transform.parent=null;
				trenchcoat.transform.rigidbody.useGravity = true;
				StartCoroutine( GoToGameOver() );
			}
		}
	}

	public IEnumerator GoToGameOver()
	{
		yield return new WaitForSeconds(1.5f);
		PlayerPrefs.SetInt("score", GameObject.FindObjectOfType<Score>().score);
		Application.LoadLevel (3);
	}
}
