using UnityEngine;
using System.Collections;

public class TrampSpikes : MonoBehaviour {

	bool enableSpikes;
	public GameObject gameObectSpikes;
	public float timeUp;
	public float timeDown;

	// Use this for initialization
	void Start () {
		enableSpikes = true;
		StartCoroutine( "ToggleSpikes" );
	}
		
	IEnumerator ToggleSpikes() {
		while (true) {
			yield return new WaitForSeconds(enableSpikes ? timeUp : timeDown);
			gameObectSpikes.SetActive( enableSpikes );
			enableSpikes = !enableSpikes;
		}
	}


}
