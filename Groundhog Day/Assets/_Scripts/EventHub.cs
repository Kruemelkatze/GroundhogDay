using UnityEngine;
using System.Collections;

public class EventHub : MonoBehaviour {

	#region Event delegates
	public delegate void VoidEvent();
	public delegate void IntegerParamEvent (int value);
	public delegate void GameObjectParamEvent(GameObject obj);
	public delegate void GameObjectIntegerParamEvent(GameObject enemy, int value);
	public delegate void MovementParamEvent(Vector3 position, Vector3 location, bool lerp = false);

	#endregion


	#region Events
	public event VoidEvent LookLeftEvent;
	public event VoidEvent LookRightEvent;
	public event MovementParamEvent MoveCameraEvent;

	//Village
	public event VoidEvent SetSoldierNameKnown;
	#endregion

	#region Triggers
	public void TriggerLookLeftEvent() {
		if(LookLeftEvent != null)
			LookLeftEvent ();
	}

	public void TriggerLookRightEvent() {
		if(LookRightEvent != null)
			LookRightEvent ();
	}

	public void TriggerMoveCameraEvent(Vector3 position, Vector3 location, bool lerp = false) {
		if(MoveCameraEvent != null)
			MoveCameraEvent (position, location, lerp);
	}

	public void TriggerSetSoldierNameKnown() {
		if(SetSoldierNameKnown != null)
			SetSoldierNameKnown ();
	}

	//You get the idea on how this is done...
	//Generic .Invoke(...) cannot be done, as the event fields cannot be accessed from outside this class :(
	#endregion
}
