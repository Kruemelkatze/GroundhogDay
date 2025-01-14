﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//Original code by https://bitbucket.org/BoredMormon/
public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	public static GameObject item;    // i changed itembeigdraged to item.


	static Transform startParent;
	static Vector3 startPosition;
	bool start = true;
	//Sprite sprite;

	public void OnBeginDrag(PointerEventData eventData)
	{
		item = gameObject;
		startPosition = transform.position;
		startParent = transform.parent;

		GetComponent<CanvasGroup>().blocksRaycasts = false;
		//item.GetComponent<LayoutElement>().ignoreLayout = true;
		item.transform.SetParent(item.transform.parent.parent);
	}


	public void OnDrag(PointerEventData eventData)
	{

		transform.position = Input.mousePosition;
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		item = null;
		transform.parent = startParent;
		transform.position = startPosition;
		GetComponent<CanvasGroup>().blocksRaycasts = true;
		//item.GetComponent<LayoutElement>().ignoreLayout = false;
	}

	public static void ResetObject(GameObject obj) {
		obj.transform.parent = startParent;
		obj.transform.position = startPosition;
		obj.GetComponent<CanvasGroup>().blocksRaycasts = true;
	}

}