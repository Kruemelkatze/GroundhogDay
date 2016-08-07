using UnityEngine;
using System.Collections;

public class WellScript : InteractiveWorldObject {
	#region implemented abstract members of InteractiveWorldObject

	public override bool ItemDropped (GameObject obj)
	{
		switch (obj.name) {
			case "BucketEmptyUI": 
				FillNormalBucket ();
				return true;
			case "BucketDroolUI": 
				FillDrooledBucket ();
			return true;
			default:
				return false;
		}
		return true;
	}

	#endregion

	void FillNormalBucket ()
	{
		Grid.Inventory.BucketEmpty = false;
		Grid.Inventory.BucketDamaged = true;
	}

	void FillDrooledBucket ()
	{
		Grid.Inventory.BucketDrool = false;
		Grid.Inventory.BucketAcid = true;
	}
}
