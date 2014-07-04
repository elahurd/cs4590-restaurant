using UnityEngine;
using System.Collections;

public class Restaurant : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
	
		if (other.gameObject.tag == "Player")
			audio.PlayOneShot(audio.clip);

	}
}
