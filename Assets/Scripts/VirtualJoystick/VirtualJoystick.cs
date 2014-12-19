using UnityEngine;
using System.Collections;

public class VirtualJoystick: MonoBehaviour {


	public GameObject Vehicle;
	public GameObject ControlBase;
	public GameObject ControlKnob;
	public GameObject ControlAction;
	public float ControlKnobRadius = 0.5f;
	public float ControlBaseMargin = 0.5f;
	public float maxSpeed = 5.0f;
	public float Speed = 1.0f;

	private bool knobTouchPresed = false;
	private int knobFingerId = -1;
	
	void Start() {
	}

	void initWithAnimation () {

		Vector2 joystickFinalPosition = Camera.main.ScreenToWorldPoint( new Vector3(0, 0, 0));
		//Vector3 joystickFinalPosition = new Vector3 (ControlBase.transform.position.x, 0.0f, ControlBase.transform.position.z);
		ControlBase.transform.position = Vector3.Lerp (ControlBase.transform.position, joystickFinalPosition, 0.35f);

		Vector2 buttonFinalPosition = Camera.main.ScreenToWorldPoint( new Vector3(Screen.width, 0, 0));
		ControlAction.transform.position = Vector3.Lerp (ControlAction.transform.position, buttonFinalPosition, 0.35f);

	}
	
	void Move (Vector2 vector) {

		Vector2 direction = vector.normalized;
		Vehicle.rigidbody2D.velocity = direction * Speed;
		if (Vehicle.rigidbody2D.velocity.magnitude > maxSpeed) {
				Vehicle.rigidbody2D.velocity = Vehicle.rigidbody2D.velocity.normalized * maxSpeed;
		} 
		if (direction != Vector2.zero)
			Vehicle.transform.up = direction;
	}

	void FixedUpdate() {

	//	initWithAnimation ();

		Move (ControlKnob.transform.localPosition);
	
		if ((Application.platform == RuntimePlatform.WindowsEditor )|| (Application.platform == RuntimePlatform.OSXEditor) ){
			if (Input.GetMouseButton (0)) {
				Vector2 pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				float distance = Vector2.Distance (pos, ControlBase.transform.position);
				if (distance <= ControlKnobRadius){
					ControlKnob.transform.position = pos;
				} else {
					Vector3 newVector = new Vector3 (pos.x, pos.y, 0);
					Vector3 posi = newVector - ControlBase.transform.position;
					posi.Normalize ();
					ControlKnob.transform.position = ControlBase.transform.position;
					ControlKnob.transform.position += (ControlKnobRadius * posi);
				}
				Move (ControlKnob.transform.localPosition);
			} else {
				Vehicle.rigidbody2D.velocity = Vector2.zero;
				ControlKnob.transform.localPosition = Vector2.zero;
			}
		} else if(Application.isMobilePlatform) {
			if (Input.touchCount > 0) {
				foreach (Touch touch in Input.touches){
					Vector2 pos = Camera.main.ScreenToWorldPoint (touch.position);
					float distance = Vector2.Distance (pos, ControlBase.transform.position);
					if ( distance <= ControlKnobRadius) {
						knobFingerId = touch.fingerId;
					} 
				}
				updateKnob(Input.GetTouch (knobFingerId));
			}
		}

	}

	void updateKnob(Touch touch) {
		if ( (touch.phase == TouchPhase.Ended ) ||  (touch.phase == TouchPhase.Canceled )) {
			knobFingerId = -1;
			Vehicle.rigidbody2D.velocity = Vector2.zero;
			ControlKnob.transform.localPosition = Vector2.zero;
		} else if (touch.fingerId == knobFingerId) {
			Vector2 pos = Camera.main.ScreenToWorldPoint (touch.position);
			float distance = Vector2.Distance (pos, ControlBase.transform.position);
			if (distance < ControlKnobRadius) {
				ControlKnob.transform.position = pos;
			} else {
				Vector3 newVector = new Vector3 (pos.x, pos.y, 0);
				Vector3 posi = newVector - ControlBase.transform.position;
				posi.Normalize ();
				ControlKnob.transform.position = ControlBase.transform.position;
				ControlKnob.transform.position += (ControlKnobRadius * posi);
			}
		}

	}




}