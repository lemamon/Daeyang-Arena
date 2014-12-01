using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {
	
	private IEnumerator KillOnAnimationEnd() {
		yield return new WaitForSeconds (1.0f);
		Destroy (gameObject);
	}
	
	void Update () {
		StartCoroutine (KillOnAnimationEnd ());
	}

}
