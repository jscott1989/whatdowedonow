using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LocatorController : MonoBehaviour {

	public float horizontalMovement = 0;
	public float verticalMovement = 0;
	
	public float moveSpeed;
	public string horizontalAxis;
	public string verticalAxis;
	public GameObject disc;
	public float exaggeration;
	
	private Vector3 moveDirection;
	private float squareRadius = 1350; /*Mathf.Pow (rt.rect.width/2.0f, 2);*/

	public string UP = "w";
	public string DOWN = "s";
	public string LEFT = "a";
	public string RIGHT = "d";

	public LocatorController influenceControl;
	public float influenceAmount;

	public float momentum = 0.01f;

	public bool invertOnOtherFlip = false;
	public bool lastOtherMoreThan0 = false;

	Object lockObject = new Object();
	
	// Use this for initialization
	void Start () {
		// Force height equal to width to ensure circle for easy bound checking.
		RectTransform rt = disc.GetComponent<RectTransform> ();
		rt.sizeDelta = new Vector2 (rt.rect.width,rt.rect.width);
	}
	
	// Update is called once per frame
	void Update () {
		// Get centre of the disc for diff
//		RectTransform rt = disc.GetComponent<RectTransform> ();
//		Vector3 diff;
//		diff = transform.position - disc.transform.position;
//		float squareDistanceFromCentre = Mathf.Pow(diff.x,2) + Mathf.Pow (diff.y,2);
//		
//		// Update position
//		Vector3 currentPosition = transform.position;
//		float horizontal = Input.GetAxis (horizontalAxis);
//		float vertical = Input.GetAxis (verticalAxis);
//		moveDirection.x += horizontal;
//		moveDirection.y += vertical;
//		Vector3 target = moveDirection + currentPosition + diff*exaggeration;
//		transform.position = Vector3.Lerp (currentPosition, target, Time.deltaTime);
//		
//		// Check bounds
//		diff = transform.position - disc.transform.position;
//		squareDistanceFromCentre = Mathf.Pow(diff.x,2) + Mathf.Pow (diff.y,2);
//		if (squareDistanceFromCentre > squareRadius) {
//			transform.position = currentPosition;
//		}
//
//		horizontalMovement = transform.localPosition.x;
//		verticalMovement = transform.localPosition.y;

		if (invertOnOtherFlip) {
			if (lastOtherMoreThan0 && influenceControl.horizontalMovement < 0 || !lastOtherMoreThan0 && influenceControl.horizontalMovement >= 0) {
				applyChange((-horizontalMovement)*2, 0);
			}
			if (influenceControl.horizontalMovement < 0) {
				lastOtherMoreThan0 = false;
			} else {
				lastOtherMoreThan0 = true;
			}
		}

		float hChange = 0;
		float vChange = 0;

		if (Input.GetKey(RIGHT)) {
			hChange += 1;
		}

		if (Input.GetKey(LEFT)) {
			hChange -= 1;
		}

		if (Input.GetKey(UP)) {
			vChange += 1;
		}
		
		if (Input.GetKey(DOWN)) {
			vChange -= 1;
		}

		applyChange (hChange, vChange);

		hChange = 0;
		vChange = 0;

		// Do momentum
		hChange += (momentum * horizontalMovement);
		vChange += (momentum * verticalMovement);

		applyChange (hChange, vChange);

		if (influenceControl != null) {
			hChange = 0;
			vChange = 0;
			hChange -= (influenceAmount * horizontalMovement);
			vChange -= (influenceAmount * verticalMovement);

			influenceControl.applyChange (hChange, vChange);
		}


	}


	public void applyChange(float hChange, float vChange) {
		lock(lockObject){
			// Stuff here is locked
			horizontalMovement += hChange;
			verticalMovement += vChange;

			if (horizontalMovement < -50) {
				horizontalMovement = -50;
			} else if (horizontalMovement > 50) {
				horizontalMovement = 50;
			}
			
			if (verticalMovement < -50) {
				verticalMovement = -50;
			} else if (verticalMovement > 50) {
				verticalMovement = 50;
			}

			transform.localPosition = new Vector3(horizontalMovement, verticalMovement);
		}
	}
}
