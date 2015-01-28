using UnityEngine;
using System.Collections;

public class PauseButton : MonoBehaviour {
	
	public GameObject PauseMenu;

	public GameObject VirtualJoystick;
	public GameObject HUD;
	public GameObject Arrows;

	void Start () {
	
	}

	void OnMouseDown() {
		Debug.Log ("Pause");
		PauseMenu.SetActive (true);

		VirtualJoystick.SetActive(false);
		HUD.SetActive(false);
		Arrows.SetActive(false);
	}

	void Update () {
	
	}
}
