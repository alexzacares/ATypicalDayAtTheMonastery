using UnityEngine;
using System.Collections;

public class TrampSaw : MonoBehaviour {

	public Transform transformSaw;
	public Transform startOrigin;
	public Transform startDestine;

	public float animationDuration;
	public float delayLoopAnimaton;
	float currentTime = 0.0f;


	// Use this for initialization
	void Start () {
		StartCoroutine( MoveSaw(startOrigin, startDestine) );
	}
		

	private IEnumerator MoveSaw( Transform origin, Transform destine ) {
		float currentTime = 0;

		while (currentTime < animationDuration)   {
			transformSaw.position = Vector3.Lerp( origin.position, destine.position, (currentTime / animationDuration) );
			currentTime += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
			
		yield return new WaitForSeconds( delayLoopAnimaton );
		StopCoroutine( "MoveSaw" );
		StartCoroutine( MoveSaw(destine, origin) );

	}
	


}
