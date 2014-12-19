using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

	public GameObject background;
	
	void Start () {
		//Vector2 hudInitialPosition = Camera.main.ScreenToWorldPoint( new Vector3(Screen.width/2.0f, Screen.height , 0));
		//transform.position = hudInitialPosition;
	}

	void Update () {
		Vector2 hudFinalPosition = Camera.main.ScreenToWorldPoint( new Vector3(Screen.width/2.0f, Screen.height + background.renderer.bounds.size.y, 0));
		transform.position = Vector3.Lerp (transform.position, hudFinalPosition, 0.15f);
	
	}
}
