using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
	//Flags
	public bool Remote = false;
	public bool Trumpet = false;
	public bool IVBD = false;
	public bool KeyCard = false;
	public bool C4 = false;
	public bool File = false;
	public bool Rust = false;
	public bool Paint = false;
	public bool PaintRoller = false;
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
	public GameObject TrumpeUiObj;
	public GameObject IVBDUiObj;
	public GameObject KeyCarUiObj;
	public GameObject CUiObj;
	public GameObject FileUiObj;
	public GameObject RusUiObj;
	public GameObject PainUiObj;
	public GameObject PaintRolleUiObj;
	public GameObject BucketEmptUiObj;
	public GameObject BucketDamageUiObj;
	public GameObject BucketAciUiObj;
	public GameObject BucketDrooUiObj;
	public GameObject BucketWhiteObj;
	public GameObject BucketReUiObj;
	public GameObject MiniPotioUiObj;
	public GameObject BreaUiObj;
	public GameObject BreadPotioUiObj;
	public GameObject MiniSoldieUiObj;

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
		string name = obj.name;
		switch (name) {
		case "Remote": Remote = val; break;
		case "Trumpet": Trumpet = val; break;
		case "IVBD": IVBD = val; break;
		case "KeyCard": KeyCard = val; break;
		case "C4": C4 = val; break;
		case "File": File = val; break;
		case "Rust": Rust = val; break;
		case "Paint": Paint = val; break;
		case "PaintRoller": PaintRoller = val; break;
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
		TrumpeUiObj = GameObject.Find("TrumpetUI");
		IVBDUiObj = GameObject.Find("IVBDUI");
		KeyCarUiObj = GameObject.Find("KeyCardUI");
		CUiObj = GameObject.Find("C4UI");
		FileUiObj = GameObject.Find("FileUI");
		RusUiObj = GameObject.Find("RustUI");
		PainUiObj = GameObject.Find("PaintUI");
		PaintRolleUiObj = GameObject.Find("PaintRollerUI");
		BucketEmptUiObj = GameObject.Find("BucketEmptyUI");
		BucketDamageUiObj = GameObject.Find("BucketDamagedUI");
		BucketAciUiObj = GameObject.Find("BucketAcidUI");
		BucketDrooUiObj = GameObject.Find("BucketDroolUI");
		BucketWhiteObj = GameObject.Find("BucketWhiteUI");
		BucketReUiObj = GameObject.Find("BucketRedUI");
		MiniPotioUiObj = GameObject.Find("MiniPotionUI");
		BreaUiObj = GameObject.Find("BreadUI");
		BreadPotioUiObj = GameObject.Find("BreadPotionUI");
		MiniSoldieUiObj = GameObject.Find("MiniSoldierUI");
	}

	public void UpdateInventoryVisibility() {
		RemoteObj.SetActive(Remote);
		TrumpeUiObj.SetActive(Trumpet);
		IVBDUiObj.SetActive(IVBD);
		KeyCarUiObj.SetActive(KeyCard);
		CUiObj.SetActive(C4);
		FileUiObj.SetActive(File);
		RusUiObj.SetActive(Rust);
		PainUiObj.SetActive(Paint);
		PaintRolleUiObj.SetActive(PaintRoller);
		BucketEmptUiObj.SetActive(BucketEmpty);
		BucketDamageUiObj.SetActive(BucketDamaged);
		BucketAciUiObj.SetActive(BucketAcid);
		BucketDrooUiObj.SetActive(BucketDrool);
		BucketWhiteObj.SetActive(BucketWhite);
		BucketReUiObj.SetActive(BucketRed);
		MiniPotioUiObj.SetActive(MiniPotion);
		BreaUiObj.SetActive(Bread);
		BreadPotioUiObj.SetActive(BreadPotion);
		MiniSoldieUiObj.SetActive(MiniSoldier);
	}
}
