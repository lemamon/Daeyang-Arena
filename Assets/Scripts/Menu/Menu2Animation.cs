using UnityEngine;
using System.Collections;

public class Menu2Animation : MonoBehaviour {
	
	public GameObject mainCamera;
	public GameObject background;
	public GameObject dark;
	public GameObject wall;
	public GameObject playButton;
	public GameObject audioButton;
	public GameObject aboutButton;
	public GameObject playButtonReturn;
	
	private bool startAnimationPlay = false;
	private bool startAnimationAbout = false;
	private bool startAnimationPlayReturn = false;
	private bool startAnimationAboutReturn = false;

	void Start() {
		StartCoroutine(prepareAnimation ());
	}

	IEnumerator prepareAnimation () {
		startAnimationPlay = false;
		startAnimationPlayReturn = false;
		startAnimationAbout = false;
		startAnimationAboutReturn = false;
		gameObject.transform.position = new Vector3 (0, 0, 0);
		mainCamera.camera.orthographicSize = 4.5f;
		wall.SetActive (true);
		wall.transform.position = new Vector3 (0, 0, 0);
		background.transform.position = new Vector3 (9.5f, 0, 0);
		dark.transform.renderer.enabled = true;
		yield return new WaitForEndOfFrame();
		yield return new WaitForSeconds(0.15f);
		StartCoroutine(blink ());

	}

	IEnumerator blink () {
		yield return new WaitForSeconds(0.15f);
		dark.transform.renderer.enabled = true;
		yield return new WaitForSeconds(0.25f);
		dark.transform.renderer.enabled = false;
		yield return new WaitForSeconds(0.25f);
		dark.transform.renderer.enabled = true;
		yield return new WaitForSeconds(0.15f);
		dark.transform.renderer.enabled = false;
	}

	IEnumerator doAnimationPlay () {
		while(mainCamera.camera.orthographicSize >= 3.55f){
			mainCamera.camera.orthographicSize = Mathf.Lerp(mainCamera.camera.orthographicSize, 3.5f, 0.1f);
			yield return new WaitForEndOfFrame();
		}
		yield return new WaitForSeconds(0.15f);
		wall.SetActive (false);
		while (mainCamera.transform.position.x <= 15.95f) {
			mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, new Vector3(16.0f, 0.0f, -10.0f), 0.1f);
			yield return new WaitForEndOfFrame ();
		}
	}

	IEnumerator doAnimationPlayReturn () {
		while (mainCamera.transform.position.x >= 0.05f) {
			mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, new Vector3(0.0f, 0.0f, -10.0f), 0.1f);
			yield return new WaitForEndOfFrame ();
		}
		yield return new WaitForSeconds(0.15f);
		wall.SetActive (true);
		while(mainCamera.camera.orthographicSize <= 4.45f){
			mainCamera.camera.orthographicSize = Mathf.Lerp(mainCamera.camera.orthographicSize, 4.5f, 0.1f);
			yield return new WaitForEndOfFrame();
		}
	}

	void doAnimationAbout () {
		mainCamera.camera.transform.position = Vector3.Lerp (mainCamera.camera.transform.position,  new Vector3(5.30f, 2.3f, -10.0f), 0.1f);
		mainCamera.camera.orthographicSize = Mathf.Lerp (mainCamera.camera.orthographicSize, 0.9f, 0.1f);
	}

	void doAnimationAboutReturn () {
		mainCamera.camera.transform.position = Vector3.Lerp (mainCamera.camera.transform.position,  new Vector3(0.0f, 0.0f, -10.0f), 0.1f);
		mainCamera.camera.orthographicSize = Mathf.Lerp (mainCamera.camera.orthographicSize, 4.5f, 0.1f);
	}

	void FixedUpdate () {
		
		if (Input.GetMouseButtonDown(0)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, 1000.0f)) {
				if(hit.collider.gameObject == playButton){
					playButton.GetComponent<Animator>().SetTrigger("start");
					startAnimationPlay = true;
					startAnimationPlayReturn = false;
					startAnimationAbout = false;
					startAnimationAboutReturn = false;
				}
				if(hit.collider.gameObject == playButtonReturn){
					startAnimationPlay = false;
					startAnimationPlayReturn = true;
					startAnimationAbout = false;
					startAnimationAboutReturn = false;
				}
				if(hit.collider.gameObject == aboutButton){
					startAnimationPlay = false;
					startAnimationPlayReturn = false;
					if (startAnimationAbout == true){
						aboutButton.transform.FindChild("Credits").GetComponent<Animator>().SetTrigger("cancel");
						startAnimationAbout = false;
						startAnimationAboutReturn = true;
					} else {
						aboutButton.transform.FindChild("Credits").GetComponent<Animator>().SetTrigger("start");
						startAnimationAbout = true;
						startAnimationAboutReturn = false;
					}
				}
			}
		}
		
		if (startAnimationPlay == true) {
			StartCoroutine (doAnimationPlay ());
			startAnimationPlay = false;
		}
		
		if (startAnimationPlayReturn == true) {
			StartCoroutine(doAnimationPlayReturn ());
			startAnimationPlayReturn = false;
		}
		
		if (startAnimationAbout == true) {
			doAnimationAbout ();
		}

		if (startAnimationAboutReturn == true) {
			doAnimationAboutReturn ();
		}

	}
}
