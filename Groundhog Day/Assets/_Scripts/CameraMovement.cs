using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	Camera _camera;

	public static float rotationAngleStep = 45f;
	public static float rotationAngleMax;
	public static float rotationAngleMin;

	public float rotationSpeed = 180.0f;
	private float rotationY = 0.0f;

	public Vector3 movementVelocity = Vector3.zero;
	public float movementSmoothTime = 0.3F;

	private Quaternion rotationTo = Quaternion.identity;

	private Vector3 targetPosition;

	// Use this for initialization
	void Start () {
		rotationY = transform.position.y;
		targetPosition = transform.position;
		_camera = gameObject.GetComponent<Camera> ();

		rotationAngleMax = rotationAngleStep;
		rotationAngleMin = -rotationAngleStep;

		Grid.EventHub.LookLeftEvent += LookLeft;
		Grid.EventHub.LookRightEvent += LookRight;
		Grid.EventHub.MoveCameraEvent += MoveToPosition;
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.RotateTowards(transform.rotation, rotationTo, rotationSpeed * Time.deltaTime);
		transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref movementVelocity, movementSmoothTime);
	}

	void OnDestroy() {
		Grid.EventHub.LookLeftEvent -= LookLeft;
		Grid.EventHub.LookRightEvent -= LookRight;
		Grid.EventHub.MoveCameraEvent -= MoveToPosition;
	}

	public void MoveToPosition(Vector3 position, Vector3 rotation, bool lerp = false) {
		rotationY = rotation.y;
		rotationTo = Quaternion.Euler(0.0f, rotationY, 0.0f);

		targetPosition = position;

		if (!lerp) {
			transform.position = position;
			transform.rotation = Quaternion.LookRotation (rotation);
		}
	}

	void LookLeft ()
	{
		rotationY -= rotationAngleStep;
		rotationY = Mathf.Max (rotationAngleMin, rotationY);
		rotationTo = Quaternion.Euler(0.0f, rotationY, 0.0f);
		Debug.Log ("Look to "+rotationY);
	}

	void LookRight ()
	{
		rotationY += rotationAngleStep;
		rotationY = Mathf.Min (rotationAngleMax, rotationY);

		rotationTo = Quaternion.Euler(0.0f, rotationY, 0.0f);
		Debug.Log ("Look to "+rotationY);
	}
}
