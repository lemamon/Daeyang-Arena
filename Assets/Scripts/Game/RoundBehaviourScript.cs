using UnityEngine;
using System.Collections;

public class RoundBehaviourScript : MonoBehaviour {
	
	public GameObject PlayerVehicle;

	void Start () {
		int TypeVehicle = PlayerPrefs.GetInt ("TypeVehicle");
		Debug.Log ("TypeVehicle = "+TypeVehicle);
		switch (TypeVehicle) {
			case 0:
				PlayerVehicle = GameObject.FindGameObjectWithTag("Vehicle1");
				break;
			case 1:
				PlayerVehicle = GameObject.FindGameObjectWithTag("Vehicle2");
				break;
			case 2:
				PlayerVehicle = GameObject.FindGameObjectWithTag("Vehicle3");
				break;
			case 3:
				PlayerVehicle = GameObject.FindGameObjectWithTag("Vehicle4");
				break;
			default :
				PlayerVehicle = GameObject.FindGameObjectWithTag("Vehicle2");
				break;
		}
	}
	
	void Update () {
	
	}
}
