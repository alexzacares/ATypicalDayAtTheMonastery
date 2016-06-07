using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;
	public GameObject player3;
	public GameObject player4;

	int totalPlayers;
	int maxPlayers = 4;

	public InputController inputControllerP1;
	public InputController inputControllerP2;
	public InputController inputControllerP3;
	public InputController inputControllerP4;

	public GameObject countDownSprite3;
	public GameObject countDownSprite2;
	public GameObject countDownSprite1;
	public GameObject countDownSprite0;

	public AudioSource sonidoplay;
	public AudioSource ambiente;
	public AudioSource musicaGameplay;

	public bool countDownEnabled = true;

	private GameObject[] countDownSprites = new GameObject[4];

	// Use this for initialization
	void Start () {

		ambiente.volume = 0.45f;
		totalPlayers = Input.GetJoystickNames().Length;

		GameObject[] players = new GameObject[ maxPlayers ];

		players[0] = player1;
		players[1] = player2;
		players[2] = player3;
		players[3] = player4;

		for (int i = 0; i < maxPlayers; ++i) {
			players[i].gameObject.SetActive(false);
		}


		print( totalPlayers );

		for (int i = 0; i < totalPlayers; ++i) {
			players[i].gameObject.SetActive(true);
		}


		countDownSprites [0] = countDownSprite0;
		countDownSprites [1] = countDownSprite1;
		countDownSprites [2] = countDownSprite2;
		countDownSprites [3] = countDownSprite3;


		StartCoroutine( "CountDown" );
	}

	IEnumerator CountDown() {

		if (countDownEnabled) {
			for (int i = 3; i >= -1 ; i--) {
				if (i == -2) {
					
				}


				yield return new WaitForSeconds(1f);

				if( i == 0 )
					sonidoplay.Play ();

				if (i != -1) {
					countDownSprites [i].SetActive (true);
				}
				if (i != 3) {
					countDownSprites [i + 1].SetActive (false);
				}


			}
			ambiente.volume = 0.7f;
			musicaGameplay.Play ();


		}
		inputControllerP1.StartGame ();
		inputControllerP2.StartGame ();
		inputControllerP3.StartGame ();
		inputControllerP4.StartGame ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
