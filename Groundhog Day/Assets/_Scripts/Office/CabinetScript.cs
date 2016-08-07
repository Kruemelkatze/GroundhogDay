using UnityEngine;
using System.Collections;

public class CabinetScript : InteractiveWorldObject {
	#region implemented abstract members of InteractiveWorldObject

	public override bool ItemDropped (GameObject obj)
	{
		switch (obj.name) {
		case "KeyCardUI": 
			GetExplosives ();
			return true;
		default:
			return false;
		}
		return true;
	}

	#endregion

	void GetExplosives ()
	{
		Grid.Inventory.KeyCard = false;
		Grid.Inventory.C4 = true;
		Grid.Inventory.UpdateInventoryVisibility ();
	}
}
