using UnityEngine;
using System.Collections;

public class VirtualJoystick : MonoBehaviour {
	
	public bool isEnable;

	private VirtualJoystickButton.optionsButton buttonPressed =  VirtualJoystickButton.optionsButton.None;

	void Start () {
	}
	
	public void downButton (VirtualJoystickButton.optionsButton button) {
		buttonPressed = button;
	}

	public void pressedButton (VirtualJoystickButton.optionsButton button) {
		buttonPressed = button;
	}

	public void upButton () {
		buttonPressed =  VirtualJoystickButton.optionsButton.None;
	}

	public VirtualJoystickButton.optionsButton getVirtualKeyDown () {
		return buttonPressed;
	}


	void Update () {

		if (isEnable) {
			gameObject.SetActive(true);
		} else {
			gameObject.SetActive(false);
		}

	}
}
