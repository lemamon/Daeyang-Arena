using UnityEngine;
using System.Collections;

public class Oracle : MonoBehaviour {

	public float timerToDecision = 1.0f;
	private float timerToDecisionController = 1.0f;
	
	public GameObject box;

	void launchBox () {
		Vector2 randomPosition = Random.insideUnitCircle * 5;

		Instantiate(box, randomPosition, transform.rotation);
	}

	void Update () {
		timerToDecision -= Time.deltaTime;
		if (timerToDecision < 0) {
			timerToDecision = timerToDecisionController;
			launchBox ();
		}

	}
}
