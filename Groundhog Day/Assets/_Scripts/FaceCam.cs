using UnityEngine;
using System.Collections;

public class FaceCam : MonoBehaviour {

	public Vector3 OverrideUp = Vector3.up;

	void Start() {
		
	}

	public void Update() {
		transform.LookAt(Camera.main.transform.position, OverrideUp);
	}
}
