using UnityEngine;
using System.Collections;

public class Folow : MonoBehaviour {

	public Transform follower;
	public Transform leader;
	public Vector3 distance;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		follower.position = new Vector3( leader.position.x + distance.x, leader.position.y + distance.y, leader.position.z + distance.z );
	}
}
