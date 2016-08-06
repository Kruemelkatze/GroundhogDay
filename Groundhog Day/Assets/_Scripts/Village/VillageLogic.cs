using UnityEngine;
using System.Collections;

public class VillageLogic : MonoBehaviour {

	public Material first;
	public Material second;

	static bool _soldierNameKnown = false;

	// Use this for initialization
	void Start () {
		Grid.EventHub.SetSoldierNameKnown += OnSoldierNameKnown;
		gameObject.GetComponent<MeshRenderer> ().material = _soldierNameKnown ? second : first;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDestroy() {
		Grid.EventHub.SetSoldierNameKnown -= OnSoldierNameKnown;

	}


	void OnSoldierNameKnown ()
	{
		_soldierNameKnown = true;
	}
}
