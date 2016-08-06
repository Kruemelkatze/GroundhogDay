using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class ItemCombination : MonoBehaviour , IDropHandler{

	public GameObject PartnerItem;
	public GameObject ResultItem;

	void OnStart() 
	{
		if(PartnerItem == null || ResultItem == null) {
			throw new MissingReferenceException ();	
		}
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
		}
	}
	#endregion
}﻿