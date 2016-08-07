using UnityEngine;
using System.Collections;

public class RobotScript : InteractiveWorldObject {

	void OnMouseDown() {
		base.OnMouseDown ();

		Grid.Dialog.startDialogMechanoid ();
	}


	#region implemented abstract members of InteractiveWorldObject
	public override bool ItemDropped (GameObject obj)
	{
		switch (obj.name) {
		case "IVBDUI": 
			EatBread();
			return true;
		default:
			return false;
		}
		return true;
	}

	#endregion

	void EatBread() {
		gameObject.SetActive (false);
		Grid.Inventory.IVBD = false;
		Grid.GameLogic.RobotSatisfied = true;
		Grid.GameLogic.RobotFreeVisible = true;
		Grid.GameLogic.UpdateVisibilities ();
		Grid.GameLogic.CheckWin ();
	}
}
