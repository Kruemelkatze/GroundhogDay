using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {

	//Stores all (globally) relevant game variables
	//Camera Positions
	public Vector3 FactoryPosition;
	public Vector3 VillagePosition;
	public Vector3 StoreRoomPosition;
	public float FactoryRotation;
	public float VillageRotation;
	public float StoreRoomRotation;

	//Private Fields
	private GameObject _cameraObj;
	private CameraMovement _cameraMovement;

	void Start() {
		_cameraObj = Grid.MainCamera;
		_cameraMovement = _cameraObj.GetComponent<CameraMovement> ();
	}

	void OnDestroy() {
		/* Unregister Events */
	}

	void Update() {
		/*if (Input.GetKeyDown (KeyCode.Escape)) {
			SceneManager.LoadScene ("Title");
		}*/

		if(Input.GetKeyDown(KeyCode.LeftArrow))
		{
			Grid.EventHub.TriggerLookLeftEvent ();
		}

		if(Input.GetKeyDown(KeyCode.RightArrow))
		{
			Grid.EventHub.TriggerLookRightEvent ();
		}

		if (Input.GetKeyDown (KeyCode.F)) {
			Grid.EventHub.TriggerMoveCameraEvent (FactoryPosition, FactoryRotation, false, true);
		}

		if (Input.GetKeyDown (KeyCode.V)) {
			Grid.EventHub.TriggerMoveCameraEvent (VillagePosition, VillageRotation, false, true);
		}

		if (Input.GetKeyDown (KeyCode.S)) {
			Grid.EventHub.TriggerMoveCameraEvent (StoreRoomPosition, StoreRoomRotation, false, true);
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			Restart ();
		}

		if (Input.GetKeyDown (KeyCode.Return)) {
			Grid.EventHub.TriggerSetSoldierNameKnown ();
		}
	}

	public void Restart() {
		SceneManager.LoadScene (0);
	}
}
