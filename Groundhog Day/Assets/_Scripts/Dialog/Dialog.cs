using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Dialog : MonoBehaviour {

	private GameObject _dialogUi;
	private Text _buttonLeftText;
	private Text _buttonRightText;
	private GameObject _buttonLeft;
	private GameObject _buttonRight;
	private Text _titleText;
	private Text _dialogText;
    private bool _gnomeDialog = true;
    private bool _mechanoidDialog = true;
    private bool _VANSHATTERDialog = true;
    private int _simpleTextCounter = 0;
    private static int _nameStatus = 0;
    private bool _sameday = false;

    // Use this for initialization
    void Start () {
		_dialogUi = GameObject.Find ("DialogUI");
		_buttonLeft = GameObject.Find ("ButtonLeft");
		_buttonLeftText = GameObject.Find ("LeftButtonText").GetComponent<Text> ();
		_buttonRight = GameObject.Find ("ButtonRight");
		_buttonRightText = GameObject.Find ("RightButtonText").GetComponent<Text> ();
		_dialogText = GameObject.Find ("DialogText").GetComponent<Text> ();

		ShowDialogUi (false);
		Grid.EventHub.ShowDialogUi += ShowDialogUi;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnDestroy() {
		Grid.EventHub.ShowDialogUi -= ShowDialogUi;
	}


	public void OnLeftButtonClick ()
	{
        if (_VANSHATTERDialog)
        {
            if (_nameStatus == 1)
            {
                switch (_simpleTextCounter)
                    {
                        case 0: TextProgression("Yes, the one and only! Will you help me?", "Yes.", "No."); _simpleTextCounter=3; _sameday = false; break;
                        case 3: TextProgression("It all started when I was shooting the machines in Dr. EvilGenius' laboratory. Suddenly a portal opened and brought me to this awful place.", "*let him continue*", null); _simpleTextCounter++; break;
                        case 4: TextProgression("I tried to shoot the portal... but that made it smaller so I threw the robot out of anger.", "I'll help you. But I need your keycard.", null); _simpleTextCounter++; break;    
                        case 5: _dialogUi.SetActive(false); Grid.Inventory.KeyCard = true; Grid.Inventory.UpdateInventoryVisibility(); _nameStatus = 1; _sameday = true; break;
                    }
              }
        }
    }

	public void OnRightButtonClick ()
	{
        if (_gnomeDialog)
        {
            switch (_simpleTextCounter)
            {
                case 0: TextProgression("*Achos! Getthät rus away fromme... *sniffle*", null, "That rusty thing over there?"); _simpleTextCounter++; break;
                case 1: TextProgression("*Ewww, izzat that old machine? Thät things gross... ", null, "Okay?"); _simpleTextCounter++; break;
                case 2: TextProgression("Wait... wait wait wait... wait...    wait... ...", null, "..."); _simpleTextCounter++; break;
                case 3: TextProgression("didjoo say new machine? You gotta gimme outtä here so I can work ätthat new machine!", null, "I'll try!"); _simpleTextCounter++; break;
                case 4: _dialogUi.SetActive(false); break;
            }
        }
        if (_mechanoidDialog)
        {
            switch (_simpleTextCounter)
            {
                case 0: TextProgression("I.V.B.D", null, "I.V.B.D?"); _simpleTextCounter++; break;
                case 1: TextProgression("Hungry", null, "Yes, I know."); _simpleTextCounter++; break;
                case 2: TextProgression("I.V.B.D", null, "..."); _simpleTextCounter++; break;
                case 3: _dialogUi.SetActive(false); break;
            }
        }
        if (_VANSHATTERDialog)
        {
            if (_nameStatus == 0)
            {
                switch (_simpleTextCounter)
                {
                    case 0: TextProgression("I am trapped in this silly place and there are things that need shooting!", null, "Who are you?"); _simpleTextCounter++; break;
                    case 1: TextProgression("You have never heard of me?", null, "No, I have not."); _simpleTextCounter++; break;
                    case 2: TextProgression("Certainly you know the legend of how I destroyed Doctor Badguy's fortress with only my smallest gun?", null, "No."); _simpleTextCounter++; break;
                    case 3: TextProgression("No? Well then, Hans-Friedrich VanShatter will wait for help somebody who actually appreciates him.", null, "Okay."); _simpleTextCounter++; break;
                    case 4: TextProgression("Now go away before I shoot you!", null, "*leave him be*"); _simpleTextCounter++; break;
                    case 5: _dialogUi.SetActive(false); _nameStatus = 1; _sameday = true; break;
                }
            }
            if (_nameStatus == 1)
            {
                if (_sameday)
                {
                    _dialogUi.SetActive(false);
                }
                else
                {
                    switch (_simpleTextCounter)
                    {
                        case 0: TextProgression("I am trapped in this silly place and there are things that need shooting!", null, "Who are you?"); _simpleTextCounter++; break;
                        case 1: TextProgression("You have never heard of me?", null, "No, I have not."); _simpleTextCounter++; break;
                        case 2: TextProgression("Certainly you know the legend of how I destroyed Doctor Badguy's fortress with only my smallest gun?", null, "No."); _simpleTextCounter++; break;
                        case 3: TextProgression("No? Well then, Hans-Friedrich VanShatter will wait for help somebody who actually appreciates him.", null, "Okay."); _simpleTextCounter++; break;
                        case 4: TextProgression("Now go away before I shoot you!", null, "*leave him be*"); _simpleTextCounter++; break;
                        case 5: _dialogUi.SetActive(false); _nameStatus = 1; _sameday = true; break;
                    }
                }
            }

        }
    }

	public void ShowDialogUi(bool visible) {

        _dialogUi.SetActive (visible);
        if (visible)
        {
            Debug.Log("Show Dialog");
            _simpleTextCounter = 0;
            if (_gnomeDialog)
            {
                TextProgression("*graahh...*",null,"Hello?");
            }
            if (_VANSHATTERDialog)
            {
                if (_nameStatus == 0) {TextProgression("*Hey you theah! You must help me!", null, "Yes?");}
                if (_nameStatus == 1 && _sameday == true)  {TextProgression("Now go away before I shoot you!", null, "*leave him be*"); }
                if (_nameStatus == 1 && _sameday == false) {TextProgression("*Hey you theah! You must help me!", "Yes, Hans-Friedrich VanShatter?", "Yes?"); }

            }
            if (_mechanoidDialog)
            {
                TextProgression("Hungry", null, "You're hungry?");
            }
        }
	}

    private void TextProgression(string top, string left, string right)
    {
        if (left == null) { _buttonLeft.SetActive(false); }
        else { _buttonLeft.SetActive(true); _buttonLeftText.text = left; }

        if (right == null) { _buttonRight.SetActive(false); }
        else { _buttonRight.SetActive(true); _buttonRightText.text = right; }

        _dialogText.text = top;
    }

    public void startDialogGnome()
    {
		if (IsDialogActive ())
			return;
		
        _gnomeDialog = true;
        _mechanoidDialog = false;
        _VANSHATTERDialog = false;
        ShowDialogUi(true);
    }

    public void startDialogMechanoid()
    {
		if (IsDialogActive ())
			return;
		
        _gnomeDialog = false;
        _mechanoidDialog = true;
        _VANSHATTERDialog = false;
        ShowDialogUi(true);
    }

    public void startDialogVanShatter()
    {
		if (IsDialogActive ())
			return;
		
        _gnomeDialog = false;
        _mechanoidDialog = false;
        _VANSHATTERDialog = true;
        ShowDialogUi(true);
    }

	public bool IsDialogActive() {
		return _dialogUi.activeInHierarchy;
	}
}
