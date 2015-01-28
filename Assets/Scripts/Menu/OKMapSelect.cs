using UnityEngine;
using System.Collections;

public class OKMapSelect : MonoBehaviour {
	
	public GameObject arrowCity;
	public GameObject arrowPier;
	public GameObject arrowDesert;

	public GameObject posterCity;
	public GameObject posterPier;
	public GameObject posterDesert;
	
	private int SelectedMap = 1;
	
	void Start () {
	}
	
	void FixedUpdate () {

		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, 1000.0f)) {
				if (hit.collider.gameObject == posterCity) {
					SelectedMap = 1;
				}
				if (hit.collider.gameObject == posterPier) {
					SelectedMap = 2;
				}
				if (hit.collider.gameObject == posterDesert) {
					SelectedMap = 3;
				}
				PlayerPrefs.SetInt ("TypeSingleMulti", (int) SelectedMap);
			}
		}

		if (SelectedMap == 1) {
			arrowCity.GetComponent<Animator> ().SetBool ("selected", true);
			arrowPier.GetComponent<Animator> ().SetBool ("selected", false);
			arrowDesert.GetComponent<Animator> ().SetBool ("selected", false);
		} else if (SelectedMap == 2) {
			arrowCity.GetComponent<Animator> ().SetBool ("selected", false);
			arrowPier.GetComponent<Animator> ().SetBool ("selected", true);
			arrowDesert.GetComponent<Animator> ().SetBool ("selected", false);
		} else if (SelectedMap == 3) {
			arrowCity.GetComponent<Animator> ().SetBool ("selected", false);
			arrowPier.GetComponent<Animator> ().SetBool ("selected", false);
			arrowDesert.GetComponent<Animator> ().SetBool ("selected", true);
		}
	}


	
}
