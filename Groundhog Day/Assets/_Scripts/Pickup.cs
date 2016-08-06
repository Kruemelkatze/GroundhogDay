using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {

	void OnMouseDown() {
		Debug.Log("Clicked on "+gameObject.name); 	
		Grid.EventHub.TriggerUpdateObjectEvent (gameObject, true);
		gameObject.SetActive (false);
	}

	void Update() {
		transform.LookAt(-Camera.main.transform.position, Vector3.up);
	}
}
