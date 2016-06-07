using UnityEngine;
using System.Collections;

public class MainMenuController : MonoBehaviour {
	public Transform optionPlay;
	public Transform optionExit;
	public Transform optionCredits;
	public Transform optionHover;

	private int selected;
	private Transform[] options;


	// Use this for initialization
	void Start () {
		options = new Transform[3];
		options [0] = optionCredits;
		options [1] = optionPlay;
		options [2] = optionExit;
		selected = 1;
		ChangeOption (selected);

	}

	void ChangeOption (int position) {
		optionHover.position = options [selected].position;
		optionHover.localScale = options [selected].localScale;
	}

	// Update is called once per frame
	void Update() {

		if (Input.GetKeyDown ("space")) {
			if (selected == 0) {
				Application.LoadLevel("Credits");
			}
			if (selected == 1) {
				Application.LoadLevel("Lore");
			}
			if (selected == 2) {
				Application.Quit();
			}
		}
			
		if (Input.GetKeyDown ("a")) {
			selected = (selected + 2) % 3;
			ChangeOption (selected);
		}
			
		if (Input.GetKeyDown("d")) {
			selected = (selected + 1) % 3;
			ChangeOption (selected);
		}
	}

}