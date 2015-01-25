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
	
	// Use this for initialization
	void Start () {
		// Force height equal to width to ensure circle for easy bound checking.
		RectTransform rt = disc.GetComponent<RectTransform> ();
		rt.sizeDelta = new Vector2 (rt.rect.width,rt.rect.width);
	}
	
	// Update is called once per frame
	void Update () {
		// Get centre of the disc for diff
		RectTransform rt = disc.GetComponent<RectTransform> ();
		Vector3 diff;
		diff = transform.position - disc.transform.position;
		float squareDistanceFromCentre = Mathf.Pow(diff.x,2) + Mathf.Pow (diff.y,2);
		
		// Update position
		Vector3 currentPosition = transform.position;
		float horizontal = Input.GetAxis (horizontalAxis);
		float vertical = Input.GetAxis (verticalAxis);
		moveDirection.x += horizontal;
		moveDirection.y += vertical;
		Vector3 target = moveDirection + currentPosition + diff*exaggeration;
		transform.position = Vector3.Lerp (currentPosition, target, Time.deltaTime);
		
		// Check bounds
		diff = transform.position - disc.transform.position;
		squareDistanceFromCentre = Mathf.Pow(diff.x,2) + Mathf.Pow (diff.y,2);
		if (squareDistanceFromCentre > squareRadius) {
			transform.position = currentPosition;
		}

		horizontalMovement = transform.localPosition.x;
		verticalMovement = transform.localPosition.y;
	}
}
