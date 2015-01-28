using UnityEngine;
using System.Collections;

public class Countdown : MonoBehaviour {

	public GameObject VirtualJoystick;
	public GameObject HUD;
	public GameObject Arrows;

	private float timer = 4.5f;
    private AudioSource sfx;
    private AudioSource lvlSound;
	void Start () {
        lvlSound = Camera.main.GetComponent<AudioSource>();
        sfx = GetComponent<AudioSource>();
        sfx.Play();
	}

	void Update () {
	
		timer -= Time.deltaTime;

		if (timer < 0.0f) {
			VirtualJoystick.SetActive(true);
			HUD.SetActive(true);
			Arrows.SetActive(true);
			gameObject.SetActive(false);
            lvlSound.Play();
        }

	}
}
