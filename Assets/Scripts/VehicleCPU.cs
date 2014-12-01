using UnityEngine;
using System.Collections;

public class VehicleCPU : MonoBehaviour {
	
	public float timerToDecision = 3.5f;
	private float timerToDecisionController = 3.5f;
	
	protected Animator animator;

	private float shake = 0.0f;
	public float shakeValue = 0.2f;
	public float shakeAmount = 0.1f;
	public float decreaseFactor = 1.0f;
	private Vector3 originalPos;

	
	public GameObject item;
	public float speed = 3.5f;

	void Start () {
		animator = GetComponent<Animator>();
	}
	
	void Awake() {
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
			transform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
			shake -= Time.deltaTime * decreaseFactor;
		} else {
			shake = 0f;
		}
	}
	

	void OnCollisionEnter2D (Collision2D hit) { 
		originalPos = transform.localPosition;
		shake = shakeValue;
	}

	void FixedUpdate () {
		
		timerToDecision -= Time.deltaTime;
		if (timerToDecision < 0) {
			timerToDecision = timerToDecisionController;
			launchBullet ();
		}

		shakeCamera ();
	
		accelerationUpper ();
		turnLeft ();

			
	}


}
