using UnityEngine;
using System.Collections;

public class PowerUpBehaviour : MonoBehaviour {
	private float temp = 0f;

	void Start () {

	}
	

	void Update () {
		if (temp < PowerUpConst.FIRE_TIME_VISIBLE) {
			temp += Time.deltaTime;
		} else {
			Destroy(gameObject);		
		}
	}

	void OnTriggerEnter2D(Collider2D c){
		if (c.name == "vehicle") {
			Destroy(gameObject);
		}
	}
}
