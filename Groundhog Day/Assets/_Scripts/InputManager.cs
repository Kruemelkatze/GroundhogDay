using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.LeftArrow))
		{
			Grid.EventHub.TriggerLookLeftEvent ();
		}

		if(Input.GetKeyDown(KeyCode.RightArrow))
		{
			Grid.EventHub.TriggerLookRightEvent ();
		}

		if (Input.GetKeyDown (KeyCode.F)) {
			Grid.EventHub.TriggerMoveCameraEvent (Grid.GameLogic.FactoryPosition, Grid.GameLogic.FactoryRotation, false, true);
		}

		if (Input.GetKeyDown (KeyCode.V)) {
			Grid.EventHub.TriggerMoveCameraEvent (Grid.GameLogic.VillagePosition, Grid.GameLogic.VillageRotation, false, true);
		}

		if (Input.GetKeyDown (KeyCode.S)) {
			Grid.EventHub.TriggerMoveCameraEvent (Grid.GameLogic.StoreRoomPosition, Grid.GameLogic.StoreRoomRotation, false, true);
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			Grid.EventHub.TriggerResetEvent ();
		}

		if (Input.GetKeyDown (KeyCode.Return)) {
			Grid.EventHub.TriggerSetSoldierNameKnown ();
		}
	}
}
