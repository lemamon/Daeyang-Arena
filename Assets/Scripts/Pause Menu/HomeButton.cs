using UnityEngine;
using System.Collections;

public class HomeButton : MonoBehaviour {
 
	void Start () {
	
	}

	void OnMouseDown() {
		Debug.Log ("Menu");
		Application.LoadLevel("Menu");
	}
	 
	void FixedUpdate () {

	}


}
