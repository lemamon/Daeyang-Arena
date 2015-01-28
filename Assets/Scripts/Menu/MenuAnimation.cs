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
	private float timer = 2.25f;

	void Start () {
		gameObject.transform.position = new Vector3 (0, 0, 0);
		timer = 5.0f;
		startAnimation = false;
		wall.transform.position = new Vector3 (0, 0, 0);
		background.transform.position = new Vector3 (0, 0, 0);
		gate.transform.position = new Vector2 (0, 0);
		mainCamera.camera.orthographicSize = 5.0f;
		mainCamera.camera.transform.position = new Vector3 (0, 0, -10.0f);
		logo.transform.position = new Vector2 (0, 2);
		logo.transform.localScale = new Vector3 (1, 1, 1);
		tapToStart.SetActive (true);
		tapToStart.transform.position = new Vector3 (0, -2.5f, 0);
		locker.rigidbody2D.gravityScale = 0.0f;
		locker.rigidbody2D.velocity = Vector2.zero;
		locker.transform.position = new Vector3(0.0f, -3.75f, 0.0f);
		locker.GetComponent<Animator>().SetBool("open", true);
	}

	void doAnimation() {
		timer -= Time.deltaTime;
		
		logo.transform.localScale = Vector3.Lerp(logo.transform.localScale, new Vector3(0.75f, 0.75f, 0.75f), 0.025f);// new Vector3 (0.125f * Time.deltaTime, 0.125f * Time.deltaTime, 0);


		gate.transform.position = Vector2.Lerp (gate.transform.position, new Vector2 (0.0f, 7.0f), 0.025f);

		if (locker.transform.position.y > -0.5f) {
			locker.GetComponent<Animator>().SetBool("open", false);
			locker.transform.parent = gate.transform.parent;
		}

		if (locker.GetComponent<Animator> ().GetBool ("open") == false) {
			locker.transform.position = Vector2.Lerp(locker.transform.position, new Vector2 (0.0f, -10.0f), 0.025f);
		}
		

		mainCamera.camera.orthographicSize = Mathf.Lerp(mainCamera.camera.orthographicSize, 4.5f, 0.025f);

		timer -= Time.deltaTime;
		if (timer < 0.0f)
			gameObject.SetActive (false);

	}
	
	void Update () {

		if (startAnimation == true)
			doAnimation ();

		if (Input.GetMouseButtonDown(0)) {
			startAnimation = true;
		}

	}
}
