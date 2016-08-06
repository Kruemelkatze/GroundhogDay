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
	}

	public void OnRightButtonClick ()
	{
		Debug.Log ("Yep, Right");
	}

	public void ShowDialogUi(bool visible) {
		_dialogUi.SetActive (visible);
	}
}
