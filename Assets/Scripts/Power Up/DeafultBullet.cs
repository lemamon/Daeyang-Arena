using UnityEngine;
using System.Collections;

public class DeafultBullet : MonoBehaviour {

	public float speed = 2.0f;
	public float timerItemLifeCycle = 2.0f;
	
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
