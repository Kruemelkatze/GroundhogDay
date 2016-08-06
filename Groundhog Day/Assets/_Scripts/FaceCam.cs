using UnityEngine;
using System.Collections;

public class FaceCam : MonoBehaviour {

	public void Update() {
		transform.LookAt(-Camera.main.transform.position, Vector3.up);
	}
}
