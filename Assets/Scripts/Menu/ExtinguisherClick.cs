using UnityEngine;
using System.Collections;

public class ExtinguisherClick : MonoBehaviour {

	void OnMouseDown() {
		GetComponent<AudioSource>().Play();
		Debug.Log ("ExtinguisherClick");
	}
}
