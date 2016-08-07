using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {

	public AudioClip AudioClipOnNotPossible;
	//Stores all (globally) relevant game variables
	//Camera Positions
	public Vector3 FactoryPosition;
	public Vector3 VillagePosition;
	public Vector3 StoreRoomPosition;
	public float FactoryRotation;
	public float VillageRotation;
	public float StoreRoomRotation;


	public GameObject PortalBig;
	public GameObject PortalSmall;
	public GameObject HansInOffice;
	public bool PortalBigVisible = false;
	public bool PortalSmallVisible = true;
	public bool HansInOfficeVisible = false;

	public GameObject MachineOldEmpty;
	public GameObject MachineOldFull;
	public bool MachineOldEmptyVisible = true;
	public bool MachineOldFullVisible = false;
	public bool DEBUG = true;

	//Private Fields
	private GameObject _cameraObj;
	private CameraMovement _cameraMovement;

	void Start() {
		PortalBig = GameObject.Find("PortalBig");
		PortalSmall = GameObject.Find("PortalSmall");
		HansInOffice = GameObject.Find("HansInOffice");
		MachineOldEmpty = GameObject.Find("OldMachineEmpty");
		MachineOldFull = GameObject.Find("OldMachineFull");

		Debug.Log ("Game Object started");
		_cameraObj = Grid.MainCamera;
		_cameraMovement = _cameraObj.GetComponent<CameraMovement> ();

		Physics.queriesHitTriggers = true;
		Cursor.visible = true;
		UpdateVisibilities ();

		Grid.EventHub.ResetEvent += Restart;
		ToVillage ();
	}

	void OnDestroy() {
		/* Unregister Events */
		Grid.EventHub.ResetEvent -= Restart;
	}

	void Update() {
	}

	public void Restart() {
		SceneManager.LoadScene (0);
	}

	public void ToVillage() {
		Grid.SoundManager.PlayMusic (Grid.SoundManager.VillageTheme);
		Grid.EventHub.TriggerMoveCameraEvent (Grid.GameLogic.VillagePosition, Grid.GameLogic.VillageRotation, false, true);
	}

	public void UpdateVisibilities() {
		HansInOffice.SetActive (HansInOfficeVisible);
		PortalBig.SetActive (PortalBigVisible);
		PortalSmall.SetActive (PortalSmallVisible);
		MachineOldEmpty.SetActive (MachineOldEmptyVisible);
		MachineOldFull.SetActive (MachineOldFullVisible);
	}
}
