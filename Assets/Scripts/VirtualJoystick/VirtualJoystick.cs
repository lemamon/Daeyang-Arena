using UnityEngine;
using System.Collections;

public class VirtualJoystick: MonoBehaviour {

	private GameObject Vehicle;
	public GameObject ControlBase;
	public GameObject ControlKnob;
	public GameObject ControlAction;
	public float ControlKnobRadius = 0.5f;
	public float ControlActionRadius = 0.5f;
	public float maxSpeed = 5.0f;
	public float Speed = 1.0f;
	
	public GameObject DefaultBulllet;
	public GameObject PowerUp;

	private bool knobTouchPresed = false;
	private int knobFingerId = -1;
	
	void Start() {
		RoundBehaviourScript RoundBehaviour = FindObjectOfType (typeof(RoundBehaviourScript)) as RoundBehaviourScript;
		Vehicle = RoundBehaviour.PlayerVehicle;

		Vector2 initiallPosition = Camera.main.transform.position;
		initiallPosition = new Vector2 (initiallPosition.x,  - 1.7f);
		transform.position = initiallPosition;	
	}

	void withAnimation () {
		Vector2 finalPosition = Camera.main.transform.position;
		finalPosition = new Vector2 (finalPosition.x, finalPosition.y - 0.7f);
		transform.position = Vector2.Lerp (transform.position, finalPosition, 0.15f);
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

	void launchAction () {
	//	if (timerPowerUp > 0.0f) {
	//			Instantiate (PowerUp, Vehicle.transform.position + Vehicle.transform.up / 2, Vehicle.transform.rotation);
	//	} else {
			Instantiate (DefaultBulllet, Vehicle.transform.position + Vehicle.transform.up / 2, Vehicle.transform.rotation);
	//	}
	}

	void FixedUpdate() {

		withAnimation ();

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
					float distanceKnob = Vector2.Distance (pos, ControlBase.transform.position);
					if ( distanceKnob <= ControlKnobRadius) {
						knobFingerId = touch.fingerId;
					} 

					float distanceAction = Vector2.Distance (pos, ControlAction.transform.position);
					if (distanceAction < ControlActionRadius){
						launchAction();
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