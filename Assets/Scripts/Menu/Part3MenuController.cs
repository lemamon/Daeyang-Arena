using UnityEngine;
using System.Collections;

public class Part3MenuController : MonoBehaviour {

	private AudioSource selectSound;
	
	public GameObject mainCamera;
	public GameObject backButton;
	public GameObject okButton;
	public GameObject backButtonFromCarSelect;

	private bool animationMapReturn = false;
	private bool animationSelectCar = false;
	private bool animationMapReturnFromCarSelect = false;

	private bool flagSide = false;

	void Start () {
		
		selectSound = okButton.GetComponent<AudioSource>();
	}
	 
	void FixedUpdate () {
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, 1000.0f)) {
				if (hit.collider.gameObject == backButton) {
					animationMapReturn = true;
				}

				if (hit.collider.gameObject == okButton) {
					animationSelectCar = true;
					Invoke("PlayAudio", 1.6f);
				}

				if (hit.collider.gameObject == backButtonFromCarSelect) {
					animationMapReturnFromCarSelect = true;
					
				}
			}
		}


		if (animationSelectCar == true) {
			StartCoroutine (doAnimationSelectCar ());
			animationSelectCar = false;
		}

		if (animationMapReturnFromCarSelect == true) {
			StartCoroutine (doAnimationMapReturnFromCarSelect ());
			animationMapReturnFromCarSelect = false;
		}

		if (animationMapReturn == true) {
			StartCoroutine (doAnimationMapReturnToModeSelect ());
			animationMapReturn = false;
		}

	}

	IEnumerator doAnimationSelectCar() {
		while(mainCamera.transform.position.x <= 31.95f){
			mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, new Vector3(32.0f, mainCamera.transform.position.y, -10.0f), 0.1f);
			gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(32.5f, gameObject.transform.position.y, 0.0f), 0.1f);
			yield return new WaitForEndOfFrame();
		}
		yield return new WaitForSeconds(0.15f);
		
		StartCoroutine (doAnimationMapReturn ());
	}

	IEnumerator doAnimationMapReturn () {
		
		while(gameObject.transform.position.y >= -9.9f){
			gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(gameObject.transform.position.x, -10.0f, 0.0f), 0.1f);
			yield return new WaitForEndOfFrame();
		}
		
		while(mainCamera.camera.orthographicSize >= 3.55f){
			mainCamera.camera.orthographicSize = Mathf.Lerp(mainCamera.camera.orthographicSize, 3.5f, 0.1f);
			yield return new WaitForEndOfFrame();
		}
		yield return new WaitForSeconds(0.15f);
		
		
	}


	IEnumerator doAnimationMapReturnFromCarSelect () {
		while(mainCamera.camera.orthographicSize <= 4.45f){
			mainCamera.camera.orthographicSize = Mathf.Lerp(mainCamera.camera.orthographicSize, 4.5f, 0.1f);
			yield return new WaitForEndOfFrame();
		}
		yield return new WaitForSeconds(0.15f);
		
		while(gameObject.transform.position.y <= -0.05f){
			gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(gameObject.transform.position.x, 0.0f, 0.0f), 0.1f);
			yield return new WaitForEndOfFrame();
		}
		yield return new WaitForSeconds(0.15f);
		

	}


	IEnumerator doAnimationMapReturnToModeSelect () {
		
		while(mainCamera.transform.position.x >= 16.05f){
			mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, new Vector3(16.0f, mainCamera.transform.position.y, -10.0f), 0.1f);
			gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(16.5f, gameObject.transform.position.y, 0.0f), 0.1f);
			yield return new WaitForEndOfFrame();
		}
		yield return new WaitForSeconds(0.15f);
		
		StartCoroutine (doAnimationMapReturn ());

	}


	void PlayAudio() {
		selectSound.Play();
	}

}
