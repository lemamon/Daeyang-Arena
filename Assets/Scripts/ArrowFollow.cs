using UnityEngine;
using System.Collections;

public class ArrowFollow : MonoBehaviour {
	
	public GameObject objectToFollow1;
	public GameObject objectToFollow2;
	public GameObject objectToFollow3;
	public GameObject objectToFollow4;

	public GameObject arrow1;
	public GameObject arrow2;
	public GameObject arrow3;
	public GameObject arrow4;

	void Start () {
		 
	}

	
	void OnTriggerStay2D (Collider2D hit){
		Vector3 vectorStart = new Vector3 (Camera.main.transform.position.x, Camera.main.transform.position.y, 0);
		Vector3 vectorEnd = hit.transform.position;
		Debug.DrawLine(vectorStart, vectorEnd, Color.blue);
		
	}

	void Update() {

		Vector3 vectorStart = new Vector3 (Camera.main.transform.position.x, Camera.main.transform.position.y, 0);
		Vector3 vectorEnd = new Vector3 (objectToFollow2.transform.position.x, objectToFollow2.transform.position.y, 0);
		Debug.DrawLine(vectorStart, vectorEnd, Color.red);
		/*
		RaycastHit2D hit = Physics2D.Linecast (vectorStart, vectorEnd, Physics2D.IgnoreRaycastLayer);
		if (hit) {
			Debug.DrawLine (vectorStart, hit.transform.position, Color.green);
		} else {
			Debug.DrawLine (vectorStart, hit.transform.position, Color.white);
		}
		*/

		/*
		Vector3 a = Camera.main.transform.position;
		Vector3 b = objectToFollow.transform.position;
		Vector3 direction = b - a;
		
		Ray ray = new Ray(a, direction);
		RaycastHit hit;
		if (Camera.main.collider.Raycast(ray, out hit, direction.magnitude)) {
		//	transform.position = hit.point;
		}
*/

		/*
		//Vector3 vectorMax = Camera.main.ScreenToWorldPoint( new Vector3(Screen.width - margin, Screen.height - 4 * margin, 0));
		Vector3 vectorMax = Camera.main.ScreenToWorldPoint( new Vector3(Screen.width - margin, Screen.height - 4 * margin, 0));
		Vector3 vectorMin = Camera.main.ScreenToWorldPoint( new Vector3(margin, margin, 0));

		Vector3 vector =  new Vector3();
		//vector.x = objectToFollow.transform.position.x;
		//vector.y = objectToFollow.transform.position.y;

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
	*/
	}
}
