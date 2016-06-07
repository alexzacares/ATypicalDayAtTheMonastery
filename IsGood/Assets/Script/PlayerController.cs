using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public int countDeath;

	public Transform pointToSpawn;
	public int idPlayer;
	public Animator animatorController;

	public float speed;
	public float clamSpeed;
	public float forceJump;

	public bool isDead;
	private Transform playerPosition;

	public AudioSource audiomuerte;
	public AudioSource audioRespawn;


	//public GameObject ParticulaSpawn;

	void Start () {
		isDead = false;
		countDeath = 0;
		playerPosition = gameObject.transform;

		speed = 50.0f;
		clamSpeed = 4.0f;
		forceJump = 20.0f;

		FirstSpawn();

	}

	public void Kill() {
		if (isDead)
			return;

		isDead = true;
		++countDeath;

		animatorController.SetTrigger( "KILL" );

		int newPhase = countDeath;
		audiomuerte.Play ();
		if (newPhase > 2) {
			newPhase = 2;


		}

		animatorController.SetInteger( "PHASE", newPhase );

		print ( "NUEVA FASE " + newPhase );

		ApplayPowerUps();

		Invoke ("Spawn", 2.0F);
	}

	public void ApplayPowerUps() {
		if (countDeath == 1) {
			speed = 55.0f;
			clamSpeed = 4.3f;
			forceJump = 25.0f;

		} else if (countDeath == 2) {
			speed = 60.0f;
			clamSpeed = 4.6f;
			forceJump = 30.0f;

		} else if (countDeath == 3) { 
			speed = 65.0f;
			clamSpeed = 4.9f;
			forceJump = 35.0f;

		} else {
			speed = 70.0f;
			clamSpeed = 5.2f;
			forceJump = 40.0f;

		}
	}
	public void FirstSpawn(){

		animatorController.SetTrigger( "IDLE" );
		playerPosition.position = pointToSpawn.position;
		isDead = false;
	}


	public void Spawn() {
		animatorController.SetTrigger( "IDLE" );
		playerPosition.position = pointToSpawn.position;
		isDead = false;
		audioRespawn.Play ();
		//Instantiate (ParticulaSpawn, new Vector3(0,0,0), Quaternion.identity);
	}

	public void FinishedRun( int scoreRun ) {
		print ( scoreRun + " posicion del jugador " + idPlayer );
		Save.playerWinner = idPlayer;
		Application.LoadLevel ("WIN");

	}

}
