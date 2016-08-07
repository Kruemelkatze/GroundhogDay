using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class ItemCombination : MonoBehaviour , IDropHandler{

	public GameObject PartnerItem;
	public GameObject ResultItem;

	ItemCombination[] _allItemCombinations;

	void Start() 
	{
		_allItemCombinations = gameObject.GetComponents<ItemCombination> ();
	}

	#region IdropHandler implementation
	public void OnDrop(PointerEventData eventData)
	{
		var obj = DragHandler.item;

		if (obj == null)
			return;

		bool itemFitting = PartnerItem == obj;

		if (itemFitting) {
			Grid.EventHub.TriggerUpdateObjectEvent (gameObject, false);
			Grid.EventHub.TriggerUpdateObjectEvent (PartnerItem, false);
			Grid.EventHub.TriggerUpdateObjectEvent (ResultItem, true);
			Grid.SoundManager.PlaySingle (Grid.SoundManager.OnCombinationSound);
		} else if(!OneOfTheOtherFits(obj)) {
			Grid.SoundManager.PlaySingle (Grid.SoundManager.OnNotPossibleSound);
		}
	}
	#endregion

	bool OneOfTheOtherFits(GameObject obj) {
		foreach(ItemCombination combi in _allItemCombinations) 
		{
			if (combi.PartnerItem == obj) {
				return true;
			}
		}
		return false;
	}
}﻿