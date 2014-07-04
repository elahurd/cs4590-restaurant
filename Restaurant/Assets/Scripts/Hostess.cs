using UnityEngine;
using System.Collections;

public class Hostess : MonoBehaviour {

	public AudioClip greet;
	public AudioClip reserve;

	private float reserveTime;
	private bool startReserve;

	// Use this for initialization
	void Start () {
		startReserve = false;
		reserveTime = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		
		reserveTime += Time.deltaTime;

		if (!audio.isPlaying && reserveTime > greet.length && startReserve) {
			audio.clip = reserve;
			audio.loop = true;
			audio.Play ();
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			startReserve = false;
			if (audio.isPlaying) {
				audio.Stop();
				audio.loop = false;
				audio.clip = greet;
				audio.Play();
			}
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "Player") {
			startReserve = true; //start mumbling after Player has left trigger zone
		}
	}
}
