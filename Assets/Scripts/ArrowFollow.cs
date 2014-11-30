﻿using UnityEngine;
using System.Collections;

public class ArrowFollow : MonoBehaviour {

	public GameObject objectToFollow;
	public Transform objectToAnchorRotation;


	void Start () {
	
	}

	void FixedUpdate() {

		Vector3 vectorMax = Camera.main.ScreenToWorldPoint( new Vector3(Screen.width, Screen.height, 0));
		Vector3 vectorMin = Camera.main.ScreenToWorldPoint( new Vector3(0, 0, 0));
		Vector3 vector =  new Vector3();

		Debug.Log (vectorMax);

		if (objectToFollow.transform.position.x > vectorMax.x) {
			vector.x = vectorMax.x;
		} else if (objectToFollow.transform.position.x < vectorMin.x) {
			vector.x = vectorMin.x;
		} else {
			vector.x = objectToFollow.transform.position.x;
		}

		if (objectToFollow.transform.position.y > vectorMax.y) {
			vector.y = vectorMax.y;
		}
		
		else if (objectToFollow.transform.position.y < vectorMin.y) {
			vector.y = vectorMin.y;
		}else {
			vector.y = objectToFollow.transform.position.y;
		}

		transform.position = vector;

	}
}
