using UnityEngine;
using System.Collections;

public class WorldMap : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ToOffice() {
		Grid.SoundManager.PlayMusic (Grid.SoundManager.OfficeTheme);
		Grid.EventHub.TriggerMoveCameraEvent (Grid.GameLogic.StoreRoomPosition, Grid.GameLogic.StoreRoomRotation, false, true);
		CloseWorldMap ();
	}

	public void ToVillage() {
		Grid.SoundManager.PlayMusic (Grid.SoundManager.VillageTheme);
		Grid.EventHub.TriggerMoveCameraEvent (Grid.GameLogic.VillagePosition, Grid.GameLogic.VillageRotation, false, true);
		CloseWorldMap ();
	}

	public void ToFactory() {
		Grid.SoundManager.PlayMusic (Grid.SoundManager.FactoryTheme);
		Grid.EventHub.TriggerMoveCameraEvent (Grid.GameLogic.FactoryPosition, Grid.GameLogic.FactoryRotation, false, true);
		CloseWorldMap ();
	}

	public void CloseWorldMap() {
		Grid.WorldMapUI.SetActive (false);
	}

	public void ShowWorldMap() {
		if(!Grid.Dialog.IsDialogActive())			
			Grid.WorldMapUI.SetActive (true);
	}

	public void CloseEyesAndSleep() {
		Grid.EventHub.TriggerCloseEyesEvent (true);
		Invoke ("Restart", 2);
	}

	private void Restart(){
		Grid.GameLogic.Restart ();
	}
}
