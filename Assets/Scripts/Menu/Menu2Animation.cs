using UnityEngine;
using System.Collections;

public class Menu2Animation : MonoBehaviour {
	
	public GameObject mainCamera;
	public GameObject background;
	public GameObject wall;
	public GameObject playButton;
	public GameObject aboutButton;
	
	private bool startAnimationPlay = false;
	private bool startAnimationAbout = false;

	void Start () {
		startAnimationPlay = false;
		startAnimationAbout = false;
		gameObject.transform.position = new Vector3 (0, 0, 0);
		mainCamera.camera.orthographicSize = 4.5f;
		wall.SetActive (true);
		wall.transform.position = new Vector3 (0, 0, 0);
		background.transform.position = new Vector3 (9.5f, 0, 0);

	}

	IEnumerator doAnimationPlay () {
		while(mainCamera.camera.orthographicSize >= 3.6f){
			mainCamera.camera.orthographicSize = Mathf.Lerp(mainCamera.camera.orthographicSize, 3.5f, 0.1f);
			yield return new WaitForEndOfFrame();
		}
		yield return new WaitForSeconds(0.5f);
			// myTransform.position = Vector3.Lerp(startPoint, endPoint, (Time.time - delay) / duration);
		while (mainCamera.camera.orthographicSize >= 1.6f) {
			mainCamera.camera.orthographicSize = Mathf.Lerp (mainCamera.camera.orthographicSize, 1.5f, 0.1f);
			yield return new WaitForEndOfFrame ();
		}
		

		/*if (mainCamera.camera.orthographicSize > 3.5f) {
			mainCamera.camera.orthographicSize -= 2.0f * Time.deltaTime;
		} else {
			if (mainCamera.transform.position.x < 16){
				wall.SetActive (false);
				mainCamera.transform.Translate (-10.0f * Vector3.left * Time.deltaTime);
			}
		}
		*/
	}

	void doAnimationAbout () {
		mainCamera.camera.transform.position = Vector3.Lerp (mainCamera.camera.transform.position,  new Vector3(5.30f, 2.3f, -10.0f), 0.1f);
		mainCamera.camera.orthographicSize = Mathf.Lerp (mainCamera.camera.orthographicSize, 0.9f, 0.1f);
	}

	IEnumerator blink( GameObject gameObject) {
		gameObject.renderer.enabled = false;        //Making invisible
		yield return new WaitForSeconds(2.0f);        //for 2 secs
			
		gameObject.renderer.enabled = true;  //Making visible
		yield return new WaitForSeconds(1.0f);        //for 1 secs
			
		gameObject.renderer.enabled = false;        //Making invisible again
		yield return new WaitForSeconds(1.5f);        //for 1.5 secs
	}
	
	void FixedUpdate () {

		if (Input.GetMouseButtonDown(0)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, 1000.0f)) {
				if(hit.collider.gameObject == playButton){
					startAnimationPlay = true;
					startAnimationAbout = false;
				}
				if(hit.collider.gameObject == aboutButton){
					startAnimationPlay = false;
					startAnimationAbout = true;
				}
			}
		}



		
		//StartCoroutine(blink(background));

		if (startAnimationPlay == true)
			StartCoroutine(doAnimationPlay ());

		if (startAnimationAbout == true)
			doAnimationAbout ();

	
	}
}
