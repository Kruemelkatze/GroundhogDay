using UnityEngine;
using System.Collections;

public class WellScript : InteractiveWorldObject {
	#region implemented abstract members of InteractiveWorldObject

	public override bool ItemDropped (GameObject obj)
	{
		switch (obj.name) {
			case "BucketEmptyUI": 
				FillBucket ();
				return true;
			default:
				return false;
		}
		return true;
	}

	#endregion

	void FillBucket ()
	{
		Grid.Inventory.BucketEmpty = false;
		Grid.Inventory.BucketAcid = true;
	}



}
