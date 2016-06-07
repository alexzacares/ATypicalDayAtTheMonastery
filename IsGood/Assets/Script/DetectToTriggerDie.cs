using UnityEngine;
using System.Collections;

public class DetectToTriggerDie : MonoBehaviour {

	public PlayerController player;

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "DeathTouch") {
			player.Kill();
		}
	}

}
