using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public float speedUp = 1F;
	public float speedSide = 1F;

	void Update()
	{
		Move();
	}

	// Lets the player move towards its local up vector
	void Move()
	{
		Vector3 targetPosition = transform.position + (transform.up * speedUp * Time.deltaTime);

		float h = Input.GetAxis("Horizontal");
		if (Mathf.Abs(h) > 0)
		{
			targetPosition += transform.right * speedSide * h * Time.deltaTime;
		}

		transform.position = targetPosition;
		Player.position = transform.position;
	}
}
