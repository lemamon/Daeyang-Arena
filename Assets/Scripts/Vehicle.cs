using UnityEngine;
using System.Collections;

public class Vehicle : MonoBehaviour {
	
	protected Animator animator;
	
	private float shake = 0.0f;
	public float shakeValue = 0.2f;
	public float shakeAmount = 0.1f;
	public float decreaseFactor = 1.0f;
	
	public Transform cameraTransform;

	public enum optionsController {Keyboard, VirtualJoystick};
	public optionsController Controller;

	public float speed;

	void Start () {
		animator = GetComponent<Animator>();
	}
	
	void Awake() {
		if (cameraTransform == null) {
			cameraTransform = GetComponent(typeof(Transform)) as Transform;
		}
	}
	
	public void accelerationUpper () {
		rigidbody2D.velocity = speed * transform.up;
	}

	private void accelerationLower () {
		rigidbody2D.velocity = speed * -transform.up;
	}

	private void accelerationZero () {
		rigidbody2D.velocity = Vector2.zero;
	}

	public void turnRight () {
		transform.Rotate(-Vector3.forward * speed);
	}

	public void turnLeft () {
		transform.Rotate(Vector3.forward * speed);
	}

	public void launchBullet () {
	//	Instantiate(item, transform.position + transform.up/2, transform.rotation);
	}

	void FixedUpdate () {
	
		if (Controller == optionsController.Keyboard) {

			if (Input.GetKey (KeyCode.UpArrow)) {
				accelerationUpper ();
			} else if (Input.GetKey (KeyCode.DownArrow)) {
				accelerationLower ();
			} else {
				accelerationZero ();
			}

			if (Input.GetKey (KeyCode.LeftArrow)) {
				turnLeft ();
			} else  if (Input.GetKey (KeyCode.RightArrow)) {
				turnRight ();
			}

			if (Input.GetKeyDown (KeyCode.Space)) {
				launchBullet ();
			}
		
		}



			
	}


}
