using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
	public float SpeedX = 1f;
	public float SpeedY = 1f;
	public float FollowDistance = 3f;
	public float LookAtOffsetY = -10f;

	private void Update ()
	{
		Follow ( Player.position.x, Player.position.y );
		Face ( (Vector3)Player.position );
	}

	private void Follow ( float x, float y )
	{
		FollowX ( x );
		FollowY ( y );
	}

	private void FollowX ( float x )
	{
		var targetPosition = this.transform.position;
		targetPosition.x = Mathf.Lerp ( targetPosition.x, x, SpeedX * Time.deltaTime );
		this.transform.position = targetPosition;
	}

	// Moves the camera behind y
	private void FollowY ( float y )
	{
		var targetPosition = this.transform.position;
		targetPosition.y = Mathf.Lerp ( targetPosition.y, y - FollowDistance, SpeedY * Time.deltaTime );
		this.transform.position = targetPosition;
	}

	// Lets the camera always face the target
	private void Face ( Vector3 target )
	{
		transform.LookAt ( target );
		Vector3 targetEuler = this.transform.rotation.eulerAngles;
		targetEuler.x += LookAtOffsetY;
		this.transform.rotation = Quaternion.Euler ( targetEuler );
	}
}
