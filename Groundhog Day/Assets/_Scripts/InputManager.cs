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
			if (Input.GetKeyDown (KeyCode.Space)) {
				Grid.SoundManager.PlayMusic (Grid.SoundManager.VillageTheme);
				Grid.EventHub.TriggerMoveCameraEvent (Grid.GameLogic.VillagePosition, Grid.GameLogic.VillageRotation, false, true);
			}
		}
	}
}
