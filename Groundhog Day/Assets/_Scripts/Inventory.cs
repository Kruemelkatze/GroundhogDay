using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
	//Flags
	public bool Remote = false;
	public bool Trumpet = false;
	public bool IVBD = false;
	public bool IVBDWithout = false;
	public bool KeyCard = false;
	public bool C4 = false;
	public bool RemoteC4 = false;
	public bool File = false;
	public bool Rust = false;
	public bool Paint = false;
	public bool PaintRoller = false;
	public bool PaintRollerWhite = false;
	public bool PaintRollerRed = false;
	public bool BucketEmpty = false;
	public bool BucketDamaged = false;
	public bool BucketAcid = false;
	public bool BucketDrool = false;
	public bool BucketWhite = false;
	public bool BucketRed = false;
	public bool MiniPotion = false;
	public bool Bread = false;
	public bool BreadPotion = false;
	public bool MiniSoldier = false;	

	//UI GameObjects
	public GameObject RemoteObj;
	public GameObject TrumpetUiObj;
	public GameObject IVBDUiObj;
	public GameObject IVBDWithoutUiObj;
	public GameObject KeyCardUiObj;
	public GameObject C4UiObj;
	public GameObject RemoteC4UiObj;
	public GameObject FileUiObj;
	public GameObject RustUiObj;
	public GameObject PaintUiObj;
	public GameObject PaintRollerUiObj;
	public GameObject PaintRollerRedUiObj;
	public GameObject PaintRollerWhiteUiObj;
	public GameObject BucketEmptyUiObj;
	public GameObject BucketDamagedUiObj;
	public GameObject BucketAcidUiObj;
	public GameObject BucketDroolUiObj;
	public GameObject BucketWhiteObj;
	public GameObject BucketRedUiObj;
	public GameObject MiniPotionUiObj;
	public GameObject BreadUiObj;
	public GameObject BreadPotionUiObj;
	public GameObject MiniSoldierUiObj;

	// Use this for initialization
	void Start () {
		FetchObjects ();
		UpdateInventoryVisibility ();

		Grid.EventHub.UpdateObjectEvent += UpdateObject;
	}

	// Update is called once per frame
	void Update () {
	}

	void OnDestroy() {
		Grid.EventHub.UpdateObjectEvent -= UpdateObject;
	}
	public void UpdateObject(GameObject obj, bool val) {
		string name = obj.name.Replace("UI", "");
		UpdateObject (name, val);
	}
	public void UpdateObject(string name, bool val) {

		switch (name) {
			case "Remote": Remote = val; break;
			case "Trumpet": Trumpet = val; break;
			case "IVBD": IVBD = val; break;
			case "IVBDWithout": IVBDWithout = val; break;
			case "KeyCard": KeyCard = val; break;
			case "C4": C4 = val; break;
			case "RemoteC4": RemoteC4 = val; break;
			case "File": File = val; break;
			case "Rust": Rust = val; break;
			case "Paint": Paint = val; break;
			case "PaintRoller": PaintRoller = val; break;
			case "PaintRollerRed": PaintRollerRed = val; break;
			case "PaintRollerWhite": PaintRollerWhite = val; break;
			case "BucketEmpty": BucketEmpty = val; break;
			case "BucketDamaged": BucketDamaged = val; break;
			case "BucketAcid": BucketAcid = val; break;
			case "BucketDrool": BucketDrool = val; break;
			case "BucketWhite": BucketWhite = val; break;
			case "BucketRed": BucketRed = val; break;
			case "MiniPotion": MiniPotion = val; break;
			case "Bread": Bread = val; break;
			case "BreadPotion": BreadPotion = val; break;
			case "MiniSoldier": MiniSoldier	 = val; break;
		}

		UpdateInventoryVisibility ();
	}

	public void FetchObjects ()
	{
		RemoteObj = GameObject.Find("RemoteUI");
		TrumpetUiObj = GameObject.Find("TrumpetUI");
		IVBDUiObj = GameObject.Find("IVBDUI");
		IVBDWithoutUiObj = GameObject.Find("IVBDWithoutUI");
		KeyCardUiObj = GameObject.Find("KeyCardUI");
		C4UiObj = GameObject.Find("C4UI");
		RemoteC4UiObj = GameObject.Find("RemoteC4UI");
		FileUiObj = GameObject.Find("FileUI");
		RustUiObj = GameObject.Find("RustUI");
		PaintUiObj = GameObject.Find("PaintUI");
		PaintRollerUiObj = GameObject.Find("PaintRollerUI");
		PaintRollerRedUiObj = GameObject.Find("PaintRollerRedUI");
		PaintRollerWhiteUiObj = GameObject.Find("PaintRollerWhiteUI");
		BucketEmptyUiObj = GameObject.Find("BucketEmptyUI");
		BucketDamagedUiObj = GameObject.Find("BucketDamagedUI");
		BucketAcidUiObj = GameObject.Find("BucketAcidUI");
		BucketDroolUiObj = GameObject.Find("BucketDroolUI");
		BucketWhiteObj = GameObject.Find("BucketWhiteUI");
		BucketRedUiObj = GameObject.Find("BucketRedUI");
		MiniPotionUiObj = GameObject.Find("MiniPotionUI");
		BreadUiObj = GameObject.Find("BreadUI");
		BreadPotionUiObj = GameObject.Find("BreadPotionUI");
		MiniSoldierUiObj = GameObject.Find("MiniSoldierUI");
	}

	public void UpdateInventoryVisibility() {
		RemoteObj.SetActive(Remote);
		TrumpetUiObj.SetActive(Trumpet);
		IVBDUiObj.SetActive(IVBD);
		IVBDWithoutUiObj.SetActive(IVBDWithout);
		KeyCardUiObj.SetActive(KeyCard);
		C4UiObj.SetActive(C4);
		RemoteC4UiObj.SetActive(RemoteC4);
		FileUiObj.SetActive(File);
		RustUiObj.SetActive(Rust);
		PaintUiObj.SetActive(Paint);
		PaintRollerUiObj.SetActive(PaintRoller);
		PaintRollerRedUiObj.SetActive(PaintRollerRed);
		PaintRollerWhiteUiObj.SetActive(PaintRollerWhite);
		BucketEmptyUiObj.SetActive(BucketEmpty);
		BucketDamagedUiObj.SetActive(BucketDamaged);
		BucketAcidUiObj.SetActive(BucketAcid);
		BucketDroolUiObj.SetActive(BucketDrool);
		BucketWhiteObj.SetActive(BucketWhite);
		BucketRedUiObj.SetActive(BucketRed);
		MiniPotionUiObj.SetActive(MiniPotion);
		BreadUiObj.SetActive(Bread);
		BreadPotionUiObj.SetActive(BreadPotion);
		MiniSoldierUiObj.SetActive(MiniSoldier);
	}
}
