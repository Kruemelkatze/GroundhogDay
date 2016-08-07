using UnityEngine;
using System.Collections;

public class NewMachineButtonScript : MonoBehaviour {

	public ButtonState State = ButtonState.Trumpet;

	public float RotationTrumpet = 0;
	public float RotationIVBD = 270;
	public float RotationRemote = 90;

	// Use this for initialization
	void Start () {
		SwitchState (ButtonState.Trumpet);
	}

	void OnMouseDown() {
		switch (State) {
		case ButtonState.IVBD:
			SwitchState (ButtonState.Trumpet);
			break;
		case ButtonState.Remote:
			SwitchState (ButtonState.IVBD);
			break;
		case ButtonState.Trumpet:
		default:
			SwitchState (ButtonState.Remote);
			break;
		}
	}

	public void SwitchState(ButtonState state) {
		State = state;
		float rotationZ;
		switch (state) {
		case ButtonState.IVBD:
			rotationZ = RotationIVBD;
			break;
		case ButtonState.Remote:
			rotationZ = RotationRemote;
			break;
		case ButtonState.Trumpet:
		default:
			rotationZ = RotationTrumpet;
			break;
		}

		transform.localRotation = Quaternion.Euler(transform.localRotation.x, transform.localRotation.y, rotationZ);
	}


	public enum ButtonState {
		Trumpet, IVBD, Remote
	}
}
