using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {
	
	public Transform camTransform;

	public float shake = 1f;

	public float shakeAmount = 0.1f;
	public float decreaseFactor = 2.0f;
	
	Vector3 originalPos;
	
	void Awake() {
		if (camTransform == null) {
			camTransform = GetComponent(typeof(Transform)) as Transform;
		}
	}
	
	void OnEnable() {
		originalPos = camTransform.localPosition;
	}
	
	void Update() {

		if (shake > 0) {
			camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
			shake -= Time.deltaTime * decreaseFactor;
		} else {
			shake = 0f;
			//camTransform.localPosition = originalPos;
		}

	}

}