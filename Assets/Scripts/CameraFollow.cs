using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	
	public enum opitionsMode {Focus, Scene};
	
	public opitionsMode Mode;

	public GameObject objectToFollow;
	public Vector3 vectorOffset;

	void Start () {

	}

	void modeFocus () {
		Vector3 vector;
		vector = objectToFollow.transform.position;
		vector.z = -10;

		vector = vector + (objectToFollow.transform.forward * vectorOffset.z) + 
				(objectToFollow.transform.up * vectorOffset.y) + 
				(objectToFollow.transform.right * vectorOffset.x);

		transform.rotation = Quaternion.Lerp (transform.rotation, objectToFollow.transform.rotation, 0.3f);
		transform.position = vector;
	}

	void modeScene(){
		Vector3 vector;
		vector = objectToFollow.transform.position;
		vector.z = -10;
		
		vector = vector + (objectToFollow.transform.forward * vectorOffset.z) + 
			(objectToFollow.transform.up * vectorOffset.y) + 
				(objectToFollow.transform.right * vectorOffset.x);
		
		transform.position = Vector3.Lerp (transform.position, objectToFollow.transform.position, 0.3f);
		transform.position = vector;
	
	}

	void Update () {
		if (Mode == opitionsMode.Focus) {
			modeFocus ();
		} else if (Mode == opitionsMode.Scene){
			modeScene();
		}

	}


}
