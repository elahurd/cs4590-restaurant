using UnityEngine;
using System.Collections;

public class Hobo : MonoBehaviour {

	private Vector3 start;
	private Vector3 end;
	private bool toStart;
	private bool toEnd;
	private bool isMoving;

	private AudioClip[] beg;
	public AudioClip mumble;
	public AudioClip fiftycent;
	public AudioClip hamburger;
	public AudioClip carBroke;
	public AudioClip cocaCola;
	private float nextClip;

	private float begTime;

	private bool startMumbling;


	// Use this for initialization
	void Start () { 
		start = new Vector3 (-19f, .879286f, 8f);
		end = new Vector3 (-45f, .879286f, 8f);
		toStart = false;
		toEnd = true;
		isMoving = true;

		begTime = 0f; //keep track of time that hobo begs so that mumbling and begging don't overlap

		startMumbling = false;

		beg = new AudioClip[4];
		beg [0] = fiftycent;
		beg [1] = hamburger;
		beg [2] = carBroke;
		beg [3] = cocaCola;
		nextClip = 0f;


	}
	
	// Update is called once per frame
	void Update () {


		begTime += Time.deltaTime;

		//start mumbling again after done begging and Player has left trigger zone
		if (!audio.isPlaying && begTime > 1.35f && startMumbling) {
			audio.clip = mumble;
			audio.loop = true;
			audio.Play ();
		}

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
		if (other.gameObject.tag == "Player") {
			isMoving = false;
			startMumbling = false;
			begTime = 0f; //reset beg time counter

			//stop mumbling and beg (don't stop if he's still begging from before)
			if (audio.isPlaying && audio.clip == mumble) {
				audio.Stop();
				audio.loop = false;
				audio.clip = beg[(int)Mathf.Round(Random.value*3.0f)];
				audio.Play();
			}
		}
	}
	void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "Player") {
			isMoving = true; //start moving again
			startMumbling = true; //start mumbling after Player has left trigger zone
		}
	}
	


}
