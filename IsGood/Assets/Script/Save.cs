using UnityEngine;
using System.Collections;

public class Save : MonoBehaviour {

	void Awake() {
		DontDestroyOnLoad (transform.gameObject);
	}


   static public int playerWinner = 0;

}
