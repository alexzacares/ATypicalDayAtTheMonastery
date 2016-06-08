using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

	public Texture[] p0img = new Texture[5];
	public Texture[] p1img = new Texture[5];
	public Texture[] p2img = new Texture[5];
	public Texture[] p3img = new Texture[5];

	public PlayerController p0ctr;
	public PlayerController p1ctr;
	public PlayerController p2ctr;
	public PlayerController p3ctr;

	private int totalPlayers;

	private int[] deaths = new int[4];

	public int sizeHub = 70;

	// Use this for initialization
	void Start () {
		
		deaths [0] = 0;
		deaths [1] = 0;
		deaths [2] = 0;
		deaths [3] = 0;
		
		totalPlayers = Input.GetJoystickNames().Length;
		if (totalPlayers == 0) {
			totalPlayers = 4;
			print ("no joysticks connected");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		deaths [0] = Mathf.Min (p0ctr.countDeath, 4);
		deaths [1] = Mathf.Min (p1ctr.countDeath, 4);	
		deaths [2] = Mathf.Min (p2ctr.countDeath, 4);
		deaths [3] = Mathf.Min(p3ctr.countDeath, 4);

	}

	void OnGUI(){
		if (totalPlayers >= 1) {
			GUI.Label (new Rect (10, 0, sizeHub, sizeHub), p0img[deaths[0]]);	
		}
		if (totalPlayers >= 2) {
			GUI.Label (new Rect (10, 100, sizeHub, sizeHub), p1img[deaths[1]]);
		}
		if (totalPlayers >= 3) {
			GUI.Label (new Rect (Camera.current.pixelWidth - 10 - sizeHub, 0, sizeHub, sizeHub), p2img[deaths[2]]);
		}
		if (totalPlayers >= 4) {
			GUI.Label (new Rect (Camera.current.pixelWidth - 10 - sizeHub, 100, sizeHub, sizeHub), p3img[deaths[3]]);
		}
	}
}
