using UnityEngine;
using System.Collections;

public class VehicleHUD : MonoBehaviour {
	
	public Sprite spriteFullLife;
	public Sprite spriteHalfLife;
	public Sprite spriteEmptyLife;
	public GameObject Life1;
	public GameObject Life2;
	public GameObject Life3;
	public GameObject Life4;
	public GameObject Life5;

	public int totalLife = 10;
	
	void Start () {
		Life1.GetComponent<SpriteRenderer> ().sprite = spriteFullLife;
		Life2.GetComponent<SpriteRenderer> ().sprite = spriteFullLife;
		Life3.GetComponent<SpriteRenderer> ().sprite = spriteFullLife;
		Life4.GetComponent<SpriteRenderer> ().sprite = spriteFullLife;
		Life5.GetComponent<SpriteRenderer> ().sprite = spriteFullLife;
	}

	void OnTriggerEnter2D (Collider2D hit) { 
		//if (hit.gameObject.tag == "bullet") {
			totalLife--;
			Destroy(hit.gameObject);
	}
	
	void Update () {

		switch (totalLife) {
			case 0:
				GetComponent<Animator>().SetBool("Dead", true);
				Life1.GetComponent<SpriteRenderer>().sprite = spriteEmptyLife;
				break;
			case 1:
				Life1.GetComponent<SpriteRenderer>().sprite = spriteHalfLife;
				break;
			case 2:
				Life2.GetComponent<SpriteRenderer>().sprite = spriteEmptyLife;
				break;
			case 3:
				Life2.GetComponent<SpriteRenderer>().sprite = spriteHalfLife;
				break;
			case 4:
				Life3.GetComponent<SpriteRenderer>().sprite = spriteEmptyLife;
				break;
			case 5:
				Life3.GetComponent<SpriteRenderer>().sprite = spriteHalfLife;
				break;
			case 6:
				Life4.GetComponent<SpriteRenderer>().sprite = spriteEmptyLife;
				break;
			case 7:
				Life4.GetComponent<SpriteRenderer>().sprite = spriteHalfLife;
				break;
			case 8:
				Life5.GetComponent<SpriteRenderer>().sprite = spriteEmptyLife;
				break;
			case 9: 
				Life5.GetComponent<SpriteRenderer>().sprite = spriteHalfLife;
				break;
		}



	}
}
