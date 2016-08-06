using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {

	public AudioClip AudioClipOnNotPossible;
	//Stores all (globally) relevant game variables
	//Camera Positions
	public Vector3 FactoryPosition;
	public Vector3 VillagePosition;
	public Vector3 StoreRoomPosition;
	public float FactoryRotation;
	public float VillageRotation;
	public float StoreRoomRotation;

	public bool DEBUG = true;

	//Private Fields
	private GameObject _cameraObj;
	private CameraMovement _cameraMovement;

	void Start() {
		Debug.Log ("Game Object started");
		_cameraObj = Grid.MainCamera;
		_cameraMovement = _cameraObj.GetComponent<CameraMovement> ();

		Physics.queriesHitTriggers = true;
		Cursor.visible = true;

		Grid.EventHub.ResetEvent += Restart;
	}

	void OnDestroy() {
		/* Unregister Events */
		Grid.EventHub.ResetEvent -= Restart;
	}

	void Update() {
	}

	public void Restart() {
		SceneManager.LoadScene (0);
	}
}
