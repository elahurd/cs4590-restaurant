using UnityEngine;
using System.Collections;

public class BathroomGuy : MonoBehaviour {

	public AudioClip fun;
	public AudioClip hum;
	
	private float humTime;
	private bool startHum;
	
	// Use this for initialization
	void Start () {
		startHum = false;
		humTime = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		
		humTime += Time.deltaTime;
		
		if (!audio.isPlaying && humTime > fun.length && startHum) {
			audio.clip = hum;
			audio.loop = true;
			audio.Play ();
		}
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			startHum = false;
			if (audio.isPlaying) {
				audio.Stop();
				audio.loop = false;
				audio.clip = fun;
				audio.Play();
			}
		}
	}
	
	void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "Player") {
			startHum = true; //start mumbling after Player has left trigger zone
		}
	}
}
