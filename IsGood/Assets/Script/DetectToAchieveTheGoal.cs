using UnityEngine;
using System.Collections;

public class DetectToAchieveTheGoal : MonoBehaviour {

	public PlayerController player;

	static private int scoreRun;

	void Start () {
		//Required reset level 
		scoreRun = 1;
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Finish") {
			player.FinishedRun( scoreRun );
			++scoreRun;
		}
	}

}
