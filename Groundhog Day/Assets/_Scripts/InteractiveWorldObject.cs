using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public abstract class InteractiveWorldObject : FaceCam {
	public AudioClip AudioClipOnClick;

	void OnMouseDown() {
		if (AudioClipOnClick != null) {
			Grid.SoundManager.PlaySingle (AudioClipOnClick);
		}

		Debug.Log ("Clicked on " + gameObject.name);
	}

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


	public abstract bool ItemDropped(GameObject obj);

}
