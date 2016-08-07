using UnityEngine;
using System.Collections;

public class OldMachineEmptyScript : InteractiveWorldObject {

	#region implemented abstract members of InteractiveWorldObject
	public override bool ItemDropped (GameObject obj)
	{
		switch (obj.name) {
		case "BucketAcidUI": 
			Grid.GameLogic.MachineOldEmptyVisible = false;
			Grid.GameLogic.MachineOldFullVisible = true;
			Grid.GameLogic.UpdateVisibilities ();

			Grid.Inventory.BucketAcid = false;
			Grid.Inventory.BucketEmpty = true;

			Grid.Inventory.UpdateInventoryVisibility();

			DragHandler.ResetObject (GameObject.Find ("BucketEmptyUI"));
			return true;
		default:
			return false;
		}
		return true;
	}
	#endregion

}
