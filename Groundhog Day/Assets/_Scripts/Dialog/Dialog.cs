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
    private int _nameStatus = 0;

    // Use this for initialization
    void Start () {
		_dialogUi = GameObject.Find ("DialogUI");
		_buttonLeft = GameObject.Find ("ButtonLeft");
		_buttonLeftText = GameObject.Find ("LeftButtonText").GetComponent<Text> ();
		_buttonRight = GameObject.Find ("ButtonRight");
		_buttonRightText = GameObject.Find ("RightButtonText").GetComponent<Text> ();
		_dialogText = GameObject.Find ("DialogText").GetComponent<Text> ();
		_titleText = GameObject.Find ("DialogTitle").GetComponent<Text> ();

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
		Debug.Log ("Yep, Left");
        _buttonLeftText.text = "AAAAAAA";
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
                if (_nameStatus == 1) {TextProgression("*Hey you theah! You must help me!", "Yes, Hans-Friedrich VanShatter?", "Yes?"); }

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
        _gnomeDialog = true;
        _mechanoidDialog = false;
        _VANSHATTERDialog = false;
        ShowDialogUi(true);
    }

    public void startDialogMechanoid()
    {
        _gnomeDialog = false;
        _mechanoidDialog = true;
        _VANSHATTERDialog = false;
        ShowDialogUi(true);
    }

    public void startDialogVanShatter()
    {
        _gnomeDialog = false;
        _mechanoidDialog = false;
        _VANSHATTERDialog = true;
        ShowDialogUi(true);
    }
}
