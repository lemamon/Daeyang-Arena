using UnityEngine;
using System.Collections;

public class Vehicle : MonoBehaviour {
	
	protected Animator animator;

	public VirtualJoystick virtualJoystickInput;

	private float shake = 0.0f;
	public float shakeValue = 0.2f;
	public float shakeAmount = 0.1f;
	public float decreaseFactor = 1.0f;
	private Vector3 originalPos;
	
	public Transform cameraTransform;

	public enum optionsController {Accelerometer, TouchScreen, Keyboard, VirtualJoystick};
	public optionsController Controller;
	public GameObject item;
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
		animator.SetBool("Left", false);
		animator.SetBool("Right", true);
		transform.Rotate(-Vector3.forward * speed);
	}

	public void turnLeft () {
		animator.SetBool("Left", true);
		animator.SetBool("Right", false);
		transform.Rotate(Vector3.forward * speed);
	}

	public void launchBullet () {
		Instantiate(item, transform.position + transform.up/2, transform.rotation);
	}

	private void shakeCamera () {
		if (shake > 0) {
			cameraTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
			shake -= Time.deltaTime * decreaseFactor;
		} else {
			shake = 0f;
		}
	}
	

	void OnCollisionEnter2D (Collision2D hit) { 
		originalPos = cameraTransform.localPosition;
		shake = shakeValue;
	}

	void FixedUpdate () {
	
		shakeCamera ();
	
		if (Controller == optionsController.Accelerometer) {
			if (Input.acceleration.y < 0) {
				accelerationUpper ();
			}
			if (Input.acceleration.y > 0) {
				accelerationLower ();
			}
			if (Input.acceleration.x < 0) {
				turnLeft ();
			}
			if (Input.acceleration.x > 0) {
				turnRight ();
			}
		}

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

		if (Controller == optionsController.TouchScreen) {
			accelerationUpper();
			if (Input.GetMouseButton (0)) {
				if (Input.mousePosition.x >= 0 && Input.mousePosition.x <= Screen.width / 4) {
					turnLeft ();
				} else if (Input.mousePosition.x >= 3 * Screen.width / 4 && Input.mousePosition.x <= Screen.width) {
					turnRight ();
				} else {
					if (Input.GetMouseButtonDown (0)) {
						launchBullet ();
					}
				}
			}
		}


		if (Controller == optionsController.VirtualJoystick) {
			virtualJoystickInput.isEnable = true;
			accelerationUpper();
			if (virtualJoystickInput.getVirtualKeyDown() == VirtualJoystickButton.optionsButton.LeftArrow){
				turnLeft();
			} else if (virtualJoystickInput.getVirtualKeyDown() == VirtualJoystickButton.optionsButton.RightArrow){
				turnRight();
			}
			if (virtualJoystickInput.getVirtualKeyDown() == VirtualJoystickButton.optionsButton.ActionButton){
				launchBullet();
			}
		} else {
			virtualJoystickInput.isEnable = false;
		}

			
	}


}
