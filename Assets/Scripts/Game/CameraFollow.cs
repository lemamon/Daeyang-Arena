using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	
	private float timer = 4.0f;
	private float timerLerp = 1.0f;

	private GameObject objectToFollow;
	public Vector3 vectorOffset;

	void Start () {
		RoundBehaviourScript RoundBehaviour = FindObjectOfType (typeof(RoundBehaviourScript)) as RoundBehaviourScript;
		objectToFollow = RoundBehaviour.PlayerVehicle;
	}
	

	void followCar(){
		timerLerp -= Time.deltaTime;
		Vector3 vector;
		vector = objectToFollow.transform.position;
		vector.z = -10;
		if (timerLerp > 0.0f)
			transform.position = Vector3.Lerp (transform.position, vector, 0.1f);
		else
			transform.position = vector;
		/*
		Vector3 vector;
		vector = objectToFollow.transform.position;
		vector.z = -10;
		
		vector = vector + (objectToFollow.transform.forward * vectorOffset.z) + 
			(objectToFollow.transform.up * vectorOffset.y) + 
				(objectToFollow.transform.right * vectorOffset.x);
		
		transform.position = Vector3.Lerp (transform.position, objectToFollow.transform.position, 0.3f);
		transform.position = vector;
		*/
	}

	void Update () {
		
		timer -= Time.deltaTime;
		if (timer < 0.0f) {
			followCar ();
		}

	}


}
