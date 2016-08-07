using UnityEngine;
using System.Collections;

public class NewMachineScript : InteractiveWorldObject {

	private NewMachineButtonScript buttonScript;

	void Start() {
		buttonScript = gameObject.GetComponentInChildren<NewMachineButtonScript> ();
	}


	void OnMouseDown() {
		NewMachineButtonScript.ButtonState state = buttonScript.State;

		switch (state) {
		case NewMachineButtonScript.ButtonState.IVBD:
			Grid.Inventory.IVBDWithout = true;
			break;
		case NewMachineButtonScript.ButtonState.Remote:
			Grid.Inventory.Remote = true;
			break;
		case NewMachineButtonScript.ButtonState.Trumpet:
		default:
			Grid.Inventory.Trumpet = true;
			break;
		}

		Grid.GameLogic.MachineNewOkVisible = false;
		Grid.GameLogic.MachineNewDeadVisible = true;
		Grid.GameLogic.UpdateVisibilities ();
		Grid.Inventory.UpdateInventoryVisibility ();
	}

	#region implemented abstract members of InteractiveWorldObject

	public override bool ItemDropped (GameObject obj)
	{
		throw new System.NotImplementedException ();
	}

	#endregion



}
