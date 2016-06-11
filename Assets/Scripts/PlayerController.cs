using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

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
	
	private void Update ()
	{
		this.MoveUp ();
		this.MoveSide ( Input.GetAxis ( "Horizontal" ) );

		if (this.useGyro)
		{
			this.MoveSide ( -Input.gyro.rotationRate.z * gyroSensitivity );
		}

		Player.position = (Vector2)this.transform.position;
	}

	// Lets the player move towards its local up vector
	private void MoveUp ()
	{
		this.transform.position += (this.transform.up * this.speedUp * Time.deltaTime);
	}

	// Moves the player sideways in accordance to the passed horizontal value
	private void MoveSide ( float h )
	{
		if (Mathf.Abs ( h ) > 0)
		{
			this.transform.position += this.transform.right * this.speedSide * h * Time.deltaTime;
		}
	}

	public void OnTriggerEnter2D ( Collider2D collision )
	{
		if (collision.tag == "Border")
		{
			SceneManager.LoadScene ( 0 );
		}
	}
}
