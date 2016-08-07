using UnityEngine;
using System.Collections;

public class GnomeScript : MonoBehaviour {

	public AudioClip AudioClipOnClick;

	void OnMouseOver(){
		if (Input.GetMouseButtonUp (0)) 
		{
			var obj = DragHandler.item;

			if (obj == null)
				return;

			bool itemHandled = ItemDropped (obj);
			if (itemHandled) {
				Grid.Inventory.UpdateInventoryVisibility ();
			} else if(Grid.GameLogic.AudioClipOnNotPossible != null) {
				Grid.SoundManager.PlaySingle (Grid.GameLogic.AudioClipOnNotPossible);
			}
		}
	}


	void OnMouseDown() {

		Grid.Dialog.startDialogGnome ();
	}


	#region implemented abstract members of InteractiveWorldObject
	public  bool ItemDropped (GameObject obj)
	{
		switch (obj.name) {
		case "BucketEmptyUI":
			Grid.Inventory.BucketEmpty = false;
			Grid.Inventory.BucketDrool = true;
			return true;			
		case "RemoteC4UI": 
			Grid.Inventory.RemoteC4 = false;
			Free();
			return true;
		case "RustUI":
			Grid.Inventory.Rust = false;
			Free();
			return true;
		default:
			return false;
		}
		return true;
	}

	#endregion

	void Free() {
		gameObject.SetActive (false);
	}
}
