using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {


	public GameObject objectToFollow;
	public Vector3 vectorOffset;

	void Start () {

	}
	

	void followCar(){
		
		Vector3 vector;
		vector = objectToFollow.transform.position;
		vector.z = -10;

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
		followCar();

	}


}
