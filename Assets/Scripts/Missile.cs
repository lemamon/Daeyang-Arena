using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {

	public float speed;
	public float timerItemLifeCycle = 1.0f;
	
	void Start () {
		
	}

	void Update () {
		
		timerItemLifeCycle -= Time.deltaTime;
		
		if (timerItemLifeCycle < 0) {
			Destroy (gameObject);
		}

	}
	void OnCollisionEnter2D (Collision2D hit) { 
		Destroy (gameObject);
	}
	
	void FixedUpdate () {

		rigidbody2D.velocity = speed * transform.up;

	}

	void OnTriggerEnter2D (Collider2D hit) {
		Destroy (gameObject);
	}


}
