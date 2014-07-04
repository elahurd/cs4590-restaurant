using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour {

	private Vector3 start;
	private Vector3 end;
	private bool toStart;
	private bool toEnd;
	// Use this for initialization
	void Start () {
		start = new Vector3 (28.25377f, 1.582665f, -43.80842f);
		end = new Vector3 (28.25377f, 1.582665f, 23.30737f);
		toStart = false;
		toEnd = true;
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 playerPos = GameObject.Find ("Player").transform.position;
		Vector3 carPos = transform.position;

		audio.pitch = 1.0f + 5.0f/Vector3.Distance (playerPos, carPos); //higher pitch when closer

		if ((Mathf.Abs (transform.position.z - end.z) > 0.25) && toEnd) {
			transform.Translate (new Vector3 (0f, 0f, 0.25f));
		} else if ((Mathf.Abs (transform.position.z - end.z) <= 0.25) && toEnd) {
			toEnd = false;
			toStart = true;
			transform.Translate (new Vector3 (0f, 0f, -0.25f));
		} else if ((Mathf.Abs (transform.position.z - start.z) > 0.25) && toStart) {
			transform.Translate (new Vector3 (0f, 0f, -0.25f));
		} else if ((Mathf.Abs (transform.position.z - start.z) <= 0.25) && toStart) {
			toEnd = true;
			toStart = false;
			transform.Translate (new Vector3 (0f, 0f, 0.25f));
		}	
	}



}
