using UnityEngine;
using System.Collections;

public class Dog : MonoBehaviour {

	private float startZ;
	private float endZ;
	private bool toStart;
	private bool toEnd;
	private bool isMoving;
	// Use this for initialization
	void Start () {
		startZ = -55.84409f;
		endZ = -46.10611f;
		toStart = false;
		toEnd = true;
		isMoving = true;
	}
	
	// Update is called once per frame
	void Update () {

		if (isMoving) {
			if ((Mathf.Abs (transform.position.z - endZ) > 0.1) && toEnd) {
				transform.Translate (new Vector3 (0f, 0f, 0.05f));
			} else if ((Mathf.Abs (transform.position.z - endZ) <= 0.1) && toEnd) {
				toEnd = false;
				toStart = true;
				transform.Translate (new Vector3 (0f, 0f, -0.05f));
			} else if ((Mathf.Abs (transform.position.z - startZ) > 0.1) && toStart) {
				transform.Translate (new Vector3 (0f, 0f, -0.05f));
			} else if ((Mathf.Abs (transform.position.z - startZ) <= 0.1) && toStart) {
				toEnd = true;
				toStart = false;
				transform.Translate (new Vector3 (0f, 0f, 0.05f));
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