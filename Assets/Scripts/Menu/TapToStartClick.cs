using UnityEngine;
using System.Collections;

public class TapToStartClick : MonoBehaviour {

	public GameObject nextScene;

	void Start () {
	
	}

	IEnumerator goToNextScene(){
		yield return new WaitForSeconds (2.25f);
		nextScene.SetActive (true);
		yield return new WaitForEndOfFrame();
	}

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			StartCoroutine (goToNextScene ());
		}
	}
	
}
