using UnityEngine;
using System.Collections;

public class ControllerWinLevel : MonoBehaviour {

	public Transform goToMainMenu;
	public Transform playAgaint;
	public Transform optionHover;
	public GameObject p1;
	public GameObject p2;

	private int selected;
	private Transform[] options;

	static int winner;


	// Use this for initialization
	void Start () {
		options = new Transform[2];
		options [0] = goToMainMenu;
		options [1] = playAgaint;
		selected = 1;
		ChangeOption (selected);

		print( "(" +  Save.playerWinner + " )Escena paso" );
		if ( Save.playerWinner == 1) {
			p1.SetActive (true);
		} else if ( Save.playerWinner == 2) {
			p2.SetActive (true);
		}


	}

	void ChangeOption (int position) {
		optionHover.position = options [selected].position;
		optionHover.localScale = options [selected].localScale;
	}

	// Update is called once per frame
	void Update() {

		if (Input.GetKeyDown ("space")) {
			if (selected == 0) {				
				Application.LoadLevel("MapaDefinitivo");
			}
			if (selected == 1) {
				Application.LoadLevel("MainMenu");
			}
		}

		if (Input.GetKeyDown ("a")) {
			selected = selected == 1 ? 0 : 1;
			ChangeOption (  selected  );
		}

		if (Input.GetKeyDown("d")) {
			selected = selected == 1 ? 0 : 1;
			ChangeOption (selected);
		}
	}
}
