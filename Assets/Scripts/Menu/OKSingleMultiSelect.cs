using UnityEngine;
using System.Collections;

public class OKSingleMultiSelect : MonoBehaviour {
	
	private bool startAnimationMap = false;

	
	public GameObject mainCamera;
	public GameObject Part3;


	public GameObject multi;
	public GameObject multiIcon;
	public GameObject single;
	public GameObject singleIcon;

	private SelectSingleMulti.optionsSingleMulti SelectedTypeSingleMulti;
	

	public void setTypeSingleMulti (SelectSingleMulti.optionsSingleMulti selected ){
		SelectedTypeSingleMulti = selected;
	}

	void Start () {
	
	}

	void FixedUpdate () {
		
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, 1000.0f)) {
				if (hit.collider.gameObject == gameObject) {
					//startSound.Play();
					PlayerPrefs.SetInt ("TypeSingleMulti", (int) SelectedTypeSingleMulti);
					startAnimationMap = true;
					
					Debug.Log ("SelectedTypeSingleMulti = " + SelectedTypeSingleMulti);
				}
			}
		}
		if ( (SelectedTypeSingleMulti == SelectSingleMulti.optionsSingleMulti.singleicon) ||  (SelectedTypeSingleMulti == SelectSingleMulti.optionsSingleMulti.single) ){
			multi.GetComponent<Animator> ().SetBool ("multi", false);
			multiIcon.GetComponent<Animator> ().SetBool ("multiIcon", false);
			single.GetComponent<Animator> ().SetBool ("single", true);
			singleIcon.GetComponent<Animator> ().SetBool ("singleIcon", true);
		} else {
			multi.GetComponent<Animator> ().SetBool ("multi", true);
			multiIcon.GetComponent<Animator> ().SetBool ("multiIcon", true);
			single.GetComponent<Animator> ().SetBool ("single", false);
			singleIcon.GetComponent<Animator> ().SetBool ("singleIcon", false);
		}


		if (startAnimationMap == true) {
			StartCoroutine (doAnimationMap ());
			startAnimationMap = false;
		}



	}

	IEnumerator doAnimationMap () {
		while(mainCamera.camera.orthographicSize <= 4.45f){
			mainCamera.camera.orthographicSize = Mathf.Lerp(mainCamera.camera.orthographicSize, 4.5f, 0.1f);
			yield return new WaitForEndOfFrame();
		}
		yield return new WaitForSeconds(0.15f);

		while(Part3.transform.position.y <= -0.05f){
			Part3.transform.position = Vector3.Lerp(Part3.transform.position, new Vector3(Part3.transform.position.x, 0.0f, 0.0f), 0.1f);
			yield return new WaitForEndOfFrame();
		}
		yield return new WaitForSeconds(0.15f);

	
	}
}
