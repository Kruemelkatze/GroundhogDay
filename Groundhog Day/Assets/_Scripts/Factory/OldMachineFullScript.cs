using UnityEngine;
using System.Collections;

public class OldMachineFullScript : InteractiveWorldObject {

	void OnMouseDown() {
		base.OnMouseDown ();

		Grid.GameLogic.MachineOldEmptyVisible = true;
		Grid.GameLogic.MachineOldFullVisible = false;
		Grid.GameLogic.UpdateVisibilities ();

		Grid.Inventory.IVBDWithout = true;
		Grid.Inventory.UpdateInventoryVisibility ();
	}

	#region implemented abstract members of InteractiveWorldObject
	public override bool ItemDropped (GameObject obj)
	{
		return false;
	}
	#endregion
}
