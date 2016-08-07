using UnityEngine;
using System.Collections;

public class RustScript : InteractiveWorldObject {
	#region implemented abstract members of InteractiveWorldObject

	public override bool ItemDropped (GameObject obj)
	{
		switch (obj.name) {
		case "FileUI": 
			gameObject.SetActive (false);

			Grid.Inventory.Rust = true;
			return true;
		default:
			return false;
		}
		return true;
	}

	#endregion



}
