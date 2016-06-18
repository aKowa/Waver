using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	public bool UseGyro = true;
	public float GyroSensitivity = 1f;

	public float SpeedUp = 1F;
	public float SpeedSide = 1F;

	private void Start ()
	{
		Input.gyro.enabled = true;
	}
	
	private void Update ()
	{
		MoveUp ();
		MoveSide ( Input.GetAxis ( "Horizontal" ) );

		if (UseGyro)
		{
			MoveSide ( -Input.gyro.rotationRate.z * GyroSensitivity );
		}
		Player.position = (Vector2)this.transform.position;
	}

	/// <summary>
	/// Lets the player move towards its local up vector
	/// </summary>
	private void MoveUp ()
	{
		transform.position += transform.up * SpeedUp * Time.deltaTime;
	}

	/// <summary>
	/// Moves the player sideways in accordance to the passed horizontal value
	/// </summary>
	/// <param name="h">The horizontal value between -1 and 1</param>
	private void MoveSide ( float h )
	{
		if (Mathf.Abs ( h ) > 0)
		{
			transform.position += transform.right * SpeedSide * h * Time.deltaTime;
		}
	}


	/// <summary>
	/// Checks if player collides with border and reloads scene
	/// </summary>
	public void OnTriggerEnter2D ( Collider2D collision )
	{
		if (collision.tag == "Border")
		{
			SceneManager.LoadScene ( 0 );
		}
	}
}
