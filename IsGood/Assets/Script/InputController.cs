using UnityEngine;
using System.Collections;

public enum Direction {
	TOP,
	BOTTON,
	LEFT,
	RIGHT,
	NONE
}

public class InputController : MonoBehaviour {
	
	public Rigidbody playerRigidbody;
	public Animator animatorController;
	public DetectElementByTag ground;
	public PlayerController player;
	private Direction lastDirection;
	private bool gameStarted = false;

	public AudioSource audiosalto;
	public AudioSource audiocaida;

	private bool isHiting = false;

	public void StartGame () {
		gameStarted = true;
		return;
	}

	// Use this for initialization
	void Start () {
		Debug.Log(" Hola mundo ");
		lastDirection = Direction.NONE;
	}

	Direction GetDirection( float x, float z ) {
		if (z >= 0.3f) {
			return Direction.TOP;

		} else if (z <= -0.3) {
			return Direction.BOTTON;

		} else if (x <= -0.3) {
			return Direction.LEFT;

		} else if (x >= 0.3) {
			return Direction.RIGHT;
		
		} else {
			return Direction.NONE;
		}
			
	}

	// Update is called once per frame
	void Update() {
		if (!gameStarted)
			return;
		if (player.isDead)
			return;

		float moveX = Input.GetAxis( "MoveX_P" + player.idPlayer ); 
		float moveZ = Input.GetAxis( "MoveZ_P" + player.idPlayer );

		if( isHiting && ground.IsDetected ()) {
			isHiting = false;
			audiocaida.Play ();
		}




		Direction direction = GetDirection( moveX, moveZ );

		if ( ICanJump () ) {
			Jump( moveX, moveZ, direction );

		} else {
			Run( moveX, moveZ );
		}
			
		SetAnimation( direction );


		playerRigidbody.velocity = Vector3.ClampMagnitude( playerRigidbody.velocity, player.clamSpeed );

	}

	bool ICanJump() {
		return Input.GetButtonDown( "Jump_P" + player.idPlayer );

	}
		

	void Jump( float x, float z, Direction direction ) {

		audiosalto.Play ();

		if (!ground.IsDetected ())
			return;

		isHiting = true;

		Vector3 force = new Vector3(x, player.forceJump, z);


		playerRigidbody.AddForce( force, ForceMode.Impulse );



		switch(direction) {
			case Direction.TOP: {
					animatorController.SetTrigger( "HITT" );
					//Debug.Log ("TOP");
				}
				break;
			case Direction.BOTTON: {
					animatorController.SetTrigger( "HITB" );
					//Debug.Log ("BOTTON");

				}
				break;
			case Direction.LEFT: {
					animatorController.SetTrigger( "HITL" );
					//Debug.Log ("LEFT");

				}
				break;
			case Direction.RIGHT: {
					animatorController.SetTrigger( "HITR" );
					//Debug.Log ("RIGTH");

				}
			break;
		case Direction.NONE: {
				animatorController.SetTrigger( "HITB" );
				//Debug.Log ("IDLE");

			}
			break;
		}
	

	}

	void SetAnimation( Direction direction ) {
		if (lastDirection == direction)
			return;

		if (isHiting) {
			return;
		} 

		switch(direction) {
			case Direction.TOP: {
					animatorController.SetTrigger( "TOP" );
					//Debug.Log ("TOP");
				}
				break;
			case Direction.BOTTON: {
					animatorController.SetTrigger( "BOTTON" );
					//Debug.Log ("BOTTON");

				}
				break;
			case Direction.LEFT: {
					animatorController.SetTrigger( "LEFT" );
					//Debug.Log ("LEFT");

				}
				break;
			case Direction.RIGHT: {
					animatorController.SetTrigger( "RIGTH" );
					//Debug.Log ("RIGTH");

				}
				break;
			case Direction.NONE: {
					animatorController.SetTrigger( "IDLE" );
					//Debug.Log ("IDLE");

				}
			break;
		}



		lastDirection = direction;

	}

	void Run( float moveX, float moveZ ) {
		if (Mathf.Abs (moveX) == 1 && Mathf.Abs (moveZ) == 1) {
			moveX = moveX * 0.685f;
			moveZ = moveZ * 0.685f;
		}	

		float x = player.speed * moveX;
		float z = player.speed * moveZ;

		Vector3 velocity = new Vector3(x, 0.0f, z);

		playerRigidbody.AddForce( velocity );

	}
		
}
