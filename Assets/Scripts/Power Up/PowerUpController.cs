using UnityEngine;
using System.Collections;

public class PowerUpController : MonoBehaviour {
	private GameObject power;
	private Transform max;
	private Transform min;
	private int sort;

	void Start(){
		min = transform.Find ("Min");
		max = transform.Find ("Max");
	}

	void Update(){
		Create ();
	}

	void Create(){
		float s = min.position.x;

		sort = Random.Range (0,9);

		switch (sort) {
		case PowerUpConst.FIRE:
			power = GameObject.Find (PowerUpConst.FIRE_NAME); 
			break;
		case PowerUpConst.ICE:
			power = GameObject.Find (PowerUpConst.ICE_NAME); 
			break;
		case PowerUpConst.INVISIBLE:
			power = GameObject.Find (PowerUpConst.INVISIBLE_NAME); 
			break;
		case PowerUpConst.FUEL:
			power = GameObject.Find (PowerUpConst.FUEL_NAME); 
			break;
		case PowerUpConst.SHIELD:
			power = GameObject.Find (PowerUpConst.SHIELD_NAME); 
			break;
		}

		Instantiate (power, new Vector3(Random.Range(min.position.x, max.position.x),Random.Range(min.position.y, max.position.y), 0), transform.rotation);
	}

}
