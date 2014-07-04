using UnityEngine;
using System.Collections;

public class Pacer : MonoBehaviour {

	public float start;
	public float end;
	public string xorz;
	public float speed;
	public float threshhold;

	private bool toStart;
	private bool toEnd;
	private bool isMoving;
	private float pos;
	private Vector3 moveVector;
	// Use this for initialization
	void Start () {

		toStart = false;
		toEnd = true;
		isMoving = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (xorz == "x") {
			pos = transform.position.x;
			moveVector = new Vector3(speed,0,0);
		} else if (xorz == "z") {
			pos = transform.position.z;
			moveVector = new Vector3(0,0,speed);
		}
		if (isMoving) {
			if ((Mathf.Abs (pos - end) > threshhold) && toEnd) {
				transform.Translate (moveVector);
			} else if ((Mathf.Abs (pos - end) <= threshhold) && toEnd) {
				toEnd = false;
				toStart = true;
				transform.Translate (-moveVector);
			} else if ((Mathf.Abs (pos - start) > threshhold) && toStart) {
				transform.Translate (-moveVector);
			} else if ((Mathf.Abs (pos - start) <= threshhold) && toStart) {
				toEnd = true;
				toStart = false;
				transform.Translate (moveVector);
			}	
		}
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			isMoving = false;
		}
	}
	void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "Player") {
			isMoving = true; //start moving again
		}
	}
}
