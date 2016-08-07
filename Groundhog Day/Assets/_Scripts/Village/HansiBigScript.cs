using UnityEngine;
using System.Collections;

public class HansiBigScript : InteractiveWorldObject {
	
	void OnMouseDown() {
		base.OnMouseDown ();

		Grid.Dialog.startDialogVanShatter ();
	}


	#region implemented abstract members of InteractiveWorldObject
	public override bool ItemDropped (GameObject obj)
	{
		switch (obj.name) {
		case "BreadPotionUI": 
			ShrinkHans();
			return true;
		default:
			return false;
		}
		return true;
	}

	#endregion

	void ShrinkHans() {
		Grid.Inventory.BreadPotion = false;
		Grid.Inventory.MiniSoldier = true;

		Grid.Inventory.UpdateInventoryVisibility ();

		gameObject.SetActive (false);
	}
}
