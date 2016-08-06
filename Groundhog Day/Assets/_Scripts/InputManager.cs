using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {
	bool dialog = false;

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

		if (Grid.GameLogic.DEBUG) {
			if (Input.GetKeyDown (KeyCode.F)) {
				Grid.SoundManager.PlayMusic (Grid.SoundManager.FactoryTheme);
				Grid.EventHub.TriggerMoveCameraEvent (Grid.GameLogic.FactoryPosition, Grid.GameLogic.FactoryRotation, false, true);
			}

			if (Input.GetKeyDown (KeyCode.V)) {
				Grid.SoundManager.PlayMusic (Grid.SoundManager.VillageTheme);
				Grid.EventHub.TriggerMoveCameraEvent (Grid.GameLogic.VillagePosition, Grid.GameLogic.VillageRotation, false, true);
			}

			if (Input.GetKeyDown (KeyCode.S)) {
				Grid.SoundManager.PlayMusic (Grid.SoundManager.OfficeTheme);
				Grid.EventHub.TriggerMoveCameraEvent (Grid.GameLogic.StoreRoomPosition, Grid.GameLogic.StoreRoomRotation, false, true);
			}

			if (Input.GetKeyDown (KeyCode.Escape)) {
				Grid.EventHub.TriggerResetEvent ();
			}

			if (Input.GetKeyDown (KeyCode.I)) {
				Grid.Inventory.UpdateObject (new GameObject ("BucketEmpty"), true);
			}

			if (Input.GetKeyDown (KeyCode.D)) {
				dialog = !dialog;
				Grid.EventHub.TriggerShowDialogUi (dialog);
			}
		}
	}
}
