using UnityEngine;
using System.Collections;

public class Pickup : FaceCam {

	void OnMouseDown() {
		Debug.Log("Clicked on "+gameObject.name); 	
		Grid.EventHub.TriggerUpdateObjectEvent (gameObject, true);
		gameObject.SetActive (false);
	}
}
