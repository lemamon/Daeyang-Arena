using UnityEngine;
using System.Collections;

public class Box : MonoBehaviour {
	
	public float timerToLeave = 5.0f;
	public GameObject item;

	void Start () {
	}

	void OnTriggerEnter2D (Collider2D hit) {
		Destroy (gameObject);
		GameObject instantiatedObject = Instantiate(item, transform.position, transform.rotation) as GameObject;
		instantiatedObject.transform.parent = Camera.main.transform;
		instantiatedObject.transform.localEulerAngles = Vector3.zero;
	}
	
	void Update () {
		timerToLeave -= Time.deltaTime;
		if (timerToLeave < 0) {
			Destroy(gameObject);
		}
	}
}
