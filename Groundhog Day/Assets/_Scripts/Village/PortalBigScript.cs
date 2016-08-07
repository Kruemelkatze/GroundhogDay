using UnityEngine;
using System.Collections;

public class PortalBigScript : InteractiveWorldObject {

	void OnMouseDown() {
		base.OnMouseDown ();
		if(!Grid.Dialog.IsDialogActive())
			ToOffice ();
	}

	#region implemented abstract members of InteractiveWorldObject
	public override bool ItemDropped (GameObject obj)
	{
		switch (obj.name) {
		case "MiniSoldierUI": 
			MiniHansToOffice ();
			return true;
		default:
			return false;
		}
		return true;
	}
	#endregion

	void MiniHansToOffice ()
	{
		Grid.GameLogic.HansInOfficeVisible = true;
		Grid.GameLogic.UpdateVisibilities ();
		Grid.Inventory.MiniSoldier = false;
		Grid.Inventory.UpdateInventoryVisibility ();
	}

	public void ToOffice() {
		Grid.SoundManager.PlayMusic (Grid.SoundManager.OfficeTheme);
		Grid.EventHub.TriggerMoveCameraEvent (Grid.GameLogic.StoreRoomPosition, Grid.GameLogic.StoreRoomRotation, false, true);
	}
}
