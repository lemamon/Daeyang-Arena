using UnityEngine;
using System.Collections;

public class ArrowFollow : MonoBehaviour {

	public GameObject objectToFollow;

	public float margin = 12.0f;


	void Start () {
	
	}

	void Update() {

		//Vector3 vectorMax = Camera.main.ScreenToWorldPoint( new Vector3(Screen.width - margin, Screen.height - 4 * margin, 0));
		Vector3 vectorMax = Camera.main.ScreenToWorldPoint( new Vector3(Screen.width - margin, Screen.height - 4 * margin, 0));
		Vector3 vectorMin = Camera.main.ScreenToWorldPoint( new Vector3(margin, margin, 0));

		Vector3 vector =  new Vector3();
		//vector.x = objectToFollow.transform.position.x;
		//vector.y = objectToFollow.transform.position.y;

		Vector3 vectorDebugStart = new Vector3 (Camera.main.transform.position.x, Camera.main.transform.position.y, 0);
		Vector3 vectorDebugEnd = new Vector3 (objectToFollow.transform.position.x, objectToFollow.transform.position.y, 0);
		Debug.DrawLine(vectorDebugStart, vectorDebugEnd, Color.red);

		if (objectToFollow.transform.position.x > vectorMax.x) {
			vector.x = vectorMax.x;
		} else if (objectToFollow.transform.position.x < vectorMin.x) {
			vector.x = vectorMin.x;
		} else {
			vector.x = objectToFollow.transform.position.x;
		}

		if (objectToFollow.transform.position.y > vectorMax.y) {
			vector.y = vectorMax.y;
		}
		else if (objectToFollow.transform.position.y < vectorMin.y) {
			vector.y = vectorMin.y;
		}else {
			vector.y = objectToFollow.transform.position.y;
		}

		
		transform.position = vector; 
		//transform.rotation = Quaternion.Inverse(Camera.main.transform.rotation);

	}
}
