using UnityEngine;
using System.Collections;

public class OkSelect : MonoBehaviour {
	
	public GameObject Vehicle1;
	public GameObject Vehicle2;
	public GameObject Vehicle3;
	public GameObject Vehicle4;
	public GameObject Vehicle5;
	public GameObject Vehicle6;
	public GameObject Vehicle7;
	public GameObject Vehicle8;
	public GameObject Poster;

	private SelectCarClick.optionsVehicle TypeVehicle = SelectCarClick.optionsVehicle.Car1;

	public void setCar (SelectCarClick.optionsVehicle selectedCar ){
		TypeVehicle = selectedCar;
	}

	void Start () {
	
	}


	void FixedUpdate () {

		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, 1000.0f)) {
				if (hit.collider.gameObject == gameObject) {
					PlayerPrefs.SetInt ("TypeVehicle", (int) TypeVehicle);
					Application.LoadLevel("Level 1");
				}
			}
		}

		//Debug.Log ("selectedCar = " + TypeVehicle);

		if (TypeVehicle == SelectCarClick.optionsVehicle.Car1) {
			Vehicle1.GetComponent<Animator> ().SetBool ("car1", true);
			Poster.GetComponent<Animator> ().SetBool ("poster4", true);
		} else {
			Vehicle1.GetComponent<Animator> ().SetBool ("car1", false);
			Poster.GetComponent<Animator> ().SetBool ("poster4", false);
		}
		
		if (TypeVehicle == SelectCarClick.optionsVehicle.Car2) {
			Vehicle2.GetComponent<Animator> ().SetBool ("car2", true);
			Poster.GetComponent<Animator> ().SetBool ("poster2", true);
		} else {
			Vehicle2.GetComponent<Animator> ().SetBool ("car2", false);
			Poster.GetComponent<Animator> ().SetBool ("poster2", false);
		}

		if (TypeVehicle == SelectCarClick.optionsVehicle.Car3) {
			Vehicle3.GetComponent<Animator> ().SetBool ("car3", true);
			Poster.GetComponent<Animator> ().SetBool ("poster1", true);
		} else {
			Vehicle3.GetComponent<Animator> ().SetBool ("car3", false);
			Poster.GetComponent<Animator> ().SetBool ("poster1", false);
		}
		
		if (TypeVehicle == SelectCarClick.optionsVehicle.Car4) {
			Vehicle4.GetComponent<Animator> ().SetBool ("car4", true);
			Poster.GetComponent<Animator> ().SetBool ("poster3", true);
		} else {
			Vehicle4.GetComponent<Animator> ().SetBool ("car4", false);
			Poster.GetComponent<Animator> ().SetBool ("poster3", false);
		}
		/*
		if (TypeVehicle == SelectCarClick.optionsVehicle.Car5) {
			Vehicle5.GetComponent<Animator> ().SetBool ("car5", true);
		} else {
			Vehicle5.GetComponent<Animator> ().SetBool ("car5", false);
		}
		
		if (TypeVehicle == SelectCarClick.optionsVehicle.Car6) {
			Vehicle6.GetComponent<Animator> ().SetBool ("car6", true);
		} else {
			Vehicle6.GetComponent<Animator> ().SetBool ("car6", false);
		}
		
		if (TypeVehicle == SelectCarClick.optionsVehicle.Car7) {
			Vehicle7.GetComponent<Animator> ().SetBool ("car7", true);
		} else {
			Vehicle7.GetComponent<Animator> ().SetBool ("car7", false);
		}
		
		if (TypeVehicle == SelectCarClick.optionsVehicle.Car8) {
			Vehicle8.GetComponent<Animator> ().SetBool ("car8", true);
		} else {
			Vehicle8.GetComponent<Animator> ().SetBool ("car8", false);
		}
		*/
	}
}
