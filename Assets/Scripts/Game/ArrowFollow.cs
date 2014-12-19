using UnityEngine;
using System.Collections;

public class ArrowFollow : MonoBehaviour {

	public GameObject objectToFollow;
	public GameObject player;
	public float distance = 0.5f;

	void Start () {
	
	}

	void Update () {
		
		Vector2 vectorX = Camera.main.ScreenToWorldPoint( new Vector3(Screen.width/2.0f, Screen.height/2.0f));
		Vector2 vectorA = Camera.main.ScreenToWorldPoint( new Vector3(Screen.width, Screen.height));
		Vector2 vectorB = Camera.main.ScreenToWorldPoint( new Vector3(Screen.width, 0));
		Vector2 vectorC = Camera.main.ScreenToWorldPoint( new Vector3(0, Screen.height));
		Vector2 vectorD = Camera.main.ScreenToWorldPoint( new Vector3(0, 0));

		Debug.DrawLine (vectorX, vectorA, Color.white);
		Debug.DrawLine (vectorX, vectorB, Color.white);
		Debug.DrawLine (vectorX, vectorC, Color.white);
		Debug.DrawLine (vectorX, vectorD, Color.white);
		
		Debug.DrawLine (vectorA, vectorB, Color.black);
		Debug.DrawLine (vectorA, vectorC, Color.black);
		Debug.DrawLine (vectorD, vectorB, Color.black);
		Debug.DrawLine (vectorD, vectorC, Color.black);


		Vector3 vector = objectToFollow.transform.position -  player.transform.position;
		vector.Normalize ();
		Vector3 newPosition = player.transform.position + vector * distance;
		newPosition = new Vector3 (newPosition.x, newPosition.y, 5.0f);
		transform.position = Vector3.Lerp(transform.position, newPosition, 0.05f);
		transform.up = vector;
	}

	Vector2 intersectionLineLine(Vector2 a, Vector2 b, Vector2 c, Vector2 d) {
		Vector2 u = (b - a);
		Vector2 v = (c - d);
		Vector2 w = (c - a);
		return a + u * (cross(w, v) / cross(u, v));
		
	}
	
	float cross(Vector2 u, Vector2 v) {
		return u.x * v.y - u.y * v.x; 
	}

}
