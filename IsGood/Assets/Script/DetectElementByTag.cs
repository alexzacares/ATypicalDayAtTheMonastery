using UnityEngine;
using System.Collections;

public class DetectElementByTag : MonoBehaviour {

	public string tag;
	private bool isDetected;

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerStay(Collider other) {
		if (other.gameObject.tag == tag)
			isDetected = true;
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == tag)
			isDetected = false;
	}

	public bool IsDetected() {
		return isDetected;
	}
		
}
