using UnityEngine;
using System.Collections;

public class MoveCloud : MonoBehaviour {

	public Transform cloud;
	public Transform startOrigin;
	public Transform startDestine;

	public float animationDuration;
	public float delayLoopAnimaton;
	float currentTime = 0.0f;


	// Use this for initialization
	void Start () {
		StartCoroutine( Move(startOrigin, startDestine) );
	}


	private IEnumerator Move( Transform origin, Transform destine ) {
		float currentTime = 0;

		while (currentTime < animationDuration)   {
			cloud.position = Vector3.Lerp( origin.position, destine.position, (currentTime / animationDuration) );
			currentTime += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}

		yield return new WaitForSeconds( delayLoopAnimaton );
		StopCoroutine( "Move" );
		StartCoroutine( Move(destine, origin) );

	}



}
