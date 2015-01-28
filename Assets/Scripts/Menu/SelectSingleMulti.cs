using UnityEngine;
using System.Collections;

public class SelectSingleMulti : MonoBehaviour {

	
	public enum optionsSingleMulti {single, singleicon, multi, multiicon};
	public optionsSingleMulti TypeSingleMulti;
	
	private OKSingleMultiSelect okSingleMultiSelect;
	
	void Start () {
		okSingleMultiSelect = GameObject.FindObjectOfType<OKSingleMultiSelect> ();
	}
	
	void OnMouseDown() {
		okSingleMultiSelect.setTypeSingleMulti(TypeSingleMulti);
	}

}
