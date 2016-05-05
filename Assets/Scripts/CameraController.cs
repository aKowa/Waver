using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
	public float speed = 1f;
	public float followDistance = 3f;
	public float lookAtOffsetY = -10f;

	void Update ()
	{
		Follow ( Player.position.y );
		Face ( (Vector3)Player.position );
	}

	// Moves the camera behind y
	private void Follow ( float y )
	{
		Vector3 targetPosition = this.transform.position;
		targetPosition.y = Mathf.Lerp ( targetPosition.y, y - followDistance, speed * Time.deltaTime );
		this.transform.position = targetPosition;
	}

	// Lets the camera always face the target
	private void Face ( Vector3 target )
	{
		transform.LookAt ( target );
		Vector3 targetEuler = this.transform.rotation.eulerAngles;
		targetEuler.x += lookAtOffsetY;
		this.transform.rotation = Quaternion.Euler ( targetEuler );
	}
}
