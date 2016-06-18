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
		FollowX ( Player.position.x );
		FollowY ( Player.position.y );
		Face ( (Vector3)Player.position );
	}

	/// <summary>
	/// Moves the camera behind y.
	/// </summary>
	/// <param name="x">The target x position to follow.</param>
	private void FollowX ( float x )
	{
		var targetPosition = transform.position;
		targetPosition.x = Mathf.Lerp ( targetPosition.x, x, SpeedX * Time.deltaTime );
		transform.position = targetPosition;
	}

	/// <summary>
	/// Moves the camera behind y.
	/// </summary>
	/// <param name="y">The target y position to follow.</param>
	private void FollowY ( float y )
	{
		var targetPosition = transform.position;
		targetPosition.y = Mathf.Lerp ( targetPosition.y, y - FollowDistance, SpeedY * Time.deltaTime );
		transform.position = targetPosition;
	}

	/// <summary>
	/// Lets the camera always face the target.
	/// </summary>
	/// <param name="target">The target point to look at.</param>
	private void Face ( Vector3 target )
	{
		transform.LookAt ( target );
		var targetEuler = transform.rotation.eulerAngles;
		targetEuler.x += LookAtOffsetY;
		this.transform.rotation = Quaternion.Euler ( targetEuler );
	}
}
