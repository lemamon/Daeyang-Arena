using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

	public GameObject background;

	void Start () {
		Vector2 hudInitialPosition = Camera.main.transform.position;
		hudInitialPosition = new Vector2 (hudInitialPosition.x,  1.7f);
		transform.position = hudInitialPosition;
	}

	void Update () {
		Vector2 hudFinalPosition = Camera.main.transform.position;
		hudFinalPosition = new Vector2 (hudFinalPosition.x, hudFinalPosition.y + 1.1f);
		transform.position = Vector2.Lerp (transform.position, hudFinalPosition, 0.15f);
	}
}
