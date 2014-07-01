using UnityEngine;
using System.Collections;

public class Hobo : MonoBehaviour {

	private Vector3 start;
	private Vector3 end;
	private bool toStart;
	private bool toEnd;
	private bool isMoving;

	// Use this for initialization
	void Start () { 
		start = new Vector3 (-19f, .879286f, 8f);
		end = new Vector3 (-45f, .879286f, 8f);
		toStart = false;
		toEnd = true;
		isMoving = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (isMoving) {
			if ((Mathf.Abs(transform.position.x - end.x) > 0.1) && toEnd) {
				transform.Translate(new Vector3(-0.05f,0f,0f));
			} else if ((Mathf.Abs(transform.position.x - end.x) <= 0.1) && toEnd) {
				toEnd = false;
				toStart = true;
				transform.Translate(new Vector3(0.05f,0f,0f));
			} else if ((Mathf.Abs(transform.position.x - start.x) > 0.1) && toStart) {
				transform.Translate(new Vector3(0.05f,0f,0f));
			} else if ((Mathf.Abs(transform.position.x - start.x) <= 0.1) && toStart) {
				toEnd = true;
				toStart = false;
				transform.Translate(new Vector3(-0.05f,0f,0f));
			}	
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player")
			isMoving = false;
	}
	void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "Player")
			isMoving = true;
	}
	


}
