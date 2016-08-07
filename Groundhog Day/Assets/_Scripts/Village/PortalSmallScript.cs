using UnityEngine;
using System.Collections;

public class PortalSmallScript : InteractiveWorldObject {

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
		case "PaintRollerRedUI": 
			MakePortalBig ();
			return true;
		default:
			return false;
		}
		return true;
	}

	#endregion

	public void MakePortalBig() {
		Grid.GameLogic.PortalSmallVisible = false;
		Grid.GameLogic.PortalBigVisible = true;
		Grid.Inventory.PaintRollerRed = false;
		Grid.Inventory.UpdateInventoryVisibility ();

		Grid.GameLogic.HansiSatisfied= true;
		Grid.GameLogic.HansBigInOfficeVisible = true;
		Grid.GameLogic.HansGrossVisible = false;
		Grid.GameLogic.UpdateVisibilities ();
		Grid.GameLogic.CheckWin ();

	}

	void MiniHansToOffice ()
	{
		Grid.GameLogic.HansInOfficeVisible = true;
		Grid.GameLogic.UpdateVisibilities ();
		Grid.Inventory.MiniSoldier = false;
		Grid.Inventory.UpdateInventoryVisibility ();
		Grid.GameLogic.HansiSatisfied= true;
		Grid.GameLogic.CheckWin ();

	}

	public void ToOffice() {
		Grid.SoundManager.PlayMusic (Grid.SoundManager.OfficeTheme);
		Grid.EventHub.TriggerMoveCameraEvent (Grid.GameLogic.StoreRoomPosition, Grid.GameLogic.StoreRoomRotation, false, true);
	}
}
