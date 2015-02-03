using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {		
		void Start() {
			AudioListener.pause = PlayerPrefs.GetInt("sound") != 0 ? false : true;
		}
		
		void Update () {
			AudioListener.pause = PlayerPrefs.GetInt("sound") != 0 ? false : true;
			
		}

}
