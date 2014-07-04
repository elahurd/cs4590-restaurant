using UnityEngine;
using System.Collections;

public class ReverbEnable : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			this.GetComponent<AudioReverbZone>().enabled = true;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "Player") {
			this.GetComponent<AudioReverbZone>().enabled = false;
		}
	}
}
