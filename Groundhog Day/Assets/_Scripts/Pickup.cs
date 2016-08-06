using UnityEngine;
using System.Collections;

public abstract class Pickup : MonoBehaviour {
	
	public void OnMouseOver(){
		if(Input.GetMouseButtonDown(0)){
			OnClick ();
		}
	}

	public abstract void OnClick ();
}
