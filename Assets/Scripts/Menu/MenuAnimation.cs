using UnityEngine;
using System.Collections;

public class MenuAnimation : MonoBehaviour {

	public GameObject mainCamera;
	public GameObject gate;
	public GameObject tapToStart;
	public GameObject logo;
	public GameObject locker;
	public GameObject background;
	public GameObject wall;

	private bool startAnimation = false;
	private float timer = 0.1f;

	void Start () {
		gameObject.transform.position = new Vector3 (0, 0, 0);
		timer = 5.0f;
		startAnimation = false;
		wall.transform.position = new Vector3 (0, 0, 0);
		background.transform.position = new Vector3 (0, 0, 0);
		gate.transform.position = new Vector2 (0, 0);
		mainCamera.camera.orthographicSize = 5.0f;
		logo.transform.position = new Vector2 (0, 2);
		logo.transform.localScale = new Vector3 (1, 1, 1);
		tapToStart.SetActive (true);
		tapToStart.transform.position = new Vector3 (0, -2.5f, 0);
		locker.SetActive (true);
		locker.rigidbody2D.gravityScale = 0.0f;
		locker.rigidbody2D.velocity = Vector2.zero;
		locker.transform.position = new Vector3(0.0f, -3.75f, 0.0f);
	}

	void doAnimation() {
		timer -= Time.deltaTime;
		tapToStart.SetActive (false);
		
		if (logo.transform.localScale.x > 0.75f) {
			logo.transform.localScale -= new Vector3 (0.125f * Time.deltaTime, 0.125f * Time.deltaTime, 0);
		}
		
		if (gate.transform.position.y < 7.0f)
			gate.transform.Translate (3.5f * Vector3.up * Time.deltaTime);

		if ((locker.transform.position.y < -1.0f)&&(locker.activeInHierarchy == true)) {
			locker.transform.Translate (3.5f * Vector3.up * Time.deltaTime);
		} else {
			locker.rigidbody2D.AddForce (-Vector3.forward);
			locker.rigidbody2D.gravityScale = 2.5f;
		}

		if (locker.transform.position.y < -7.0f) {
			locker.SetActive (false);
		}
		
		if (mainCamera.camera.orthographicSize > 4.5f)
			mainCamera.camera.orthographicSize -= 0.25f * Time.deltaTime;
	}
	
	void Update () {

		if (timer < 0) 
			//Start ();
			gameObject.SetActive (false);

		if (startAnimation == true)
			doAnimation ();

		if (Input.GetMouseButtonDown(0)) {
			startAnimation = true;
		}

	}
}
