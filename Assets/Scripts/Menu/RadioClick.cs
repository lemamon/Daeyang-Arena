using UnityEngine;
using System.Collections;

public class RadioClick : MonoBehaviour {

	void OnMouseDown() {
		GetComponent<AudioSource>().Play();
	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
