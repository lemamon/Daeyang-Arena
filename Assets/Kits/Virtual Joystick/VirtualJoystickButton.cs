using UnityEngine;
using System.Collections;

public class VirtualJoystickButton : MonoBehaviour {

	private VirtualJoystick virtualJoystick;

	public enum optionsButton {LeftArrow, RightArrow, ActionButton, None};

	public optionsButton Button;

	public bool isOnce = false;
	private bool onceController = false;

	void Start () {
		virtualJoystick = GameObject.FindObjectOfType<VirtualJoystick> ();
	}

	void OnMouseDown() {
		transform.localScale += new Vector3(0.05f, 0.05f, 0.05f);
		if (isOnce) {
			if (onceController == false) 
				virtualJoystick.downButton (Button);
			onceController = true; 
		} else {
			virtualJoystick.downButton (Button);
		}
	}

	void OnMouseUp () {
		onceController = false;
		transform.localScale -= new Vector3(0.05f, 0.05f, 0.05f);
		virtualJoystick.upButton();
	}
	
	void Update () {

	}


}
