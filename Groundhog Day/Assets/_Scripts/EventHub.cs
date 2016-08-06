using UnityEngine;
using System.Collections;

public class EventHub : MonoBehaviour {

	#region Event delegates
	public delegate void VoidEvent();
	public delegate void IntegerParamEvent (int value);
	public delegate void GameObjectParamEvent(GameObject obj);
	public delegate void GameObjectIntegerParamEvent(GameObject enemy, int value);
	public delegate void GameObjectBoolParamEvent(GameObject enemy, bool value);
	public delegate void MovementParamEvent(Vector3 position, Vector3 location, bool lerp = false, bool rotationReset = false);

	#endregion


	#region Events
	public event VoidEvent ResetEvent;
	public event VoidEvent LookLeftEvent;
	public event VoidEvent LookRightEvent;
	public event MovementParamEvent MoveCameraEvent;

	public event GameObjectBoolParamEvent UpdateObjectEvent;
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

	public void TriggerMoveCameraEvent(Vector3 position, Vector3 rotation, bool lerp = false, bool rotationReset = false) {
		if(MoveCameraEvent != null)
			MoveCameraEvent (position, rotation, lerp, rotationReset);
	}

	public void TriggerMoveCameraEvent(Vector3 position, float rotationY, bool lerp = false, bool rotationReset = false) {
		if(MoveCameraEvent != null)
			MoveCameraEvent (position, new Vector3(0f, rotationY, 0f), lerp, rotationReset);
	}

	public void TriggerSetSoldierNameKnown() {
		if(SetSoldierNameKnown != null)
			SetSoldierNameKnown ();
	}

	public void TriggerResetEvent() {
		if(ResetEvent != null)
			ResetEvent ();
	}

	public void TriggerUpdateObjectEvent(GameObject obj, bool val)
	{
		if (UpdateObjectEvent != null)
			UpdateObjectEvent (obj, val);
	}

	//You get the idea on how this is done...
	//Generic .Invoke(...) cannot be done, as the event fields cannot be accessed from outside this class :(
	#endregion
}
