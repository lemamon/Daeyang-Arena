using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour {

	public GameObject PauseMenu;
	
	public GameObject VirtualJoystick;
	public GameObject HUD;
	public GameObject Arrows;

	void Start () {
		
	}
	
	void OnMouseDown() {
		Debug.Log ("Play");
		PauseMenu.SetActive (false);

		VirtualJoystick.SetActive(true);
		HUD.SetActive(true);
		Arrows.SetActive(true);

	}
	
	void FixedUpdate () {
		
	}

}
