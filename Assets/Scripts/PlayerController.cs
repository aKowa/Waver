using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public bool useGyro = true;
	public float gyroSensitivity = 1f;

	public float speedUp = 1F;
	public float speedSide = 1F;

	private void Start ()
	{
		Input.gyro.enabled = true;
	}

	private void Update()
	{
		MoveUp ();
		MoveSide ( Input.GetAxis ( "Horizontal" ) );

		if (useGyro)
		{
			MoveSide ( -Input.gyro.rotationRate.z * gyroSensitivity );
		}
	}

	// Lets the player move towards its local up vector
	private void MoveUp ()
	{
		transform.position += (transform.up * speedUp * Time.deltaTime);
	}

	// Moves the player sideways in accordance to the passed horizontal value
	private void MoveSide(float h)
	{
		if (Mathf.Abs ( h ) > 0)
		{
			transform.position += transform.right * speedSide * h * Time.deltaTime;
		}
	}
}
