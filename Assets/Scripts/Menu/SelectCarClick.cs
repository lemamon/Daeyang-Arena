using UnityEngine;
using System.Collections;

public class SelectCarClick : MonoBehaviour {
	
	public enum optionsVehicle {Car1, Car2, Car3, Car4, Car5, Car6, Car7, Car8};
	public optionsVehicle TypeVehicle;

	private OkCarSelect okSelect;

	void Start () {
		okSelect = GameObject.FindObjectOfType<OkCarSelect> ();
	}

	void OnMouseDown() {
		okSelect.setCar(TypeVehicle);
	}
	void Update () {

	}

}
