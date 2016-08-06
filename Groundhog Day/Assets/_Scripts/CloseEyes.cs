using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CloseEyes : MonoBehaviour {

	public Image Upper;
	public Image Lower;

	public Vector3 movementVelocityUpper = Vector3.zero;
	public Vector3 movementVelocityLower = Vector3.zero;

	private Vector3 targetPositionUpper = Vector3.zero;
	private Vector3 targetPositionLower = Vector3.zero;
	private Vector3 originalPositionUpper;
	private Vector3 originalPositionLower;

	private static Vector3 lerpPositionUpper;
	private static Vector3 lerpPositionLower;

	public bool Close = false;
	public float movementSmoothTime = 0.15F;

	// Use this for initialization
	void Start () {
		Grid.EventHub.CloseEyesEvent += CloseThem;

		originalPositionUpper = Upper.rectTransform.localPosition;
		originalPositionLower = Lower.rectTransform.localPosition;

		if (lerpPositionUpper != null)
			Upper.rectTransform.localPosition = lerpPositionUpper;
		if (lerpPositionLower != null)
			Lower.rectTransform.localPosition = lerpPositionLower;
	}

	void OnDestroy() {
		Grid.EventHub.CloseEyesEvent -= CloseThem;
	}

	void CloseThem(bool val) {
		Close = val;
	}
	
	// Update is called once per frame
	void Update () {
		if (Close) {
			Upper.rectTransform.localPosition = Vector3.SmoothDamp (Upper.rectTransform.localPosition, targetPositionUpper, ref movementVelocityUpper, movementSmoothTime);
			Lower.rectTransform.localPosition = Vector3.SmoothDamp (Lower.rectTransform.localPosition, targetPositionLower, ref movementVelocityLower, movementSmoothTime);
		} else {
			Upper.rectTransform.localPosition = Vector3.SmoothDamp (Upper.rectTransform.localPosition, originalPositionUpper, ref movementVelocityUpper, movementSmoothTime);
			Lower.rectTransform.localPosition = Vector3.SmoothDamp (Lower.rectTransform.localPosition, originalPositionLower, ref movementVelocityLower, movementSmoothTime);
		}
	}
}
