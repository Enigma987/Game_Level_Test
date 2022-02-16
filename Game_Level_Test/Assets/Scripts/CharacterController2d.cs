using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterController2d : MonoBehaviour
{
	public float jumpForce = 400f;
	[Range(0, .3f)] public float movementSmooth = .05f;

	public LayerMask whatIsGround;
	public Transform groundCheck;


	const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
	private bool isOnGround;

	private Rigidbody2D rigidbody2d;
	private bool facingRight = true;  // For determining which way the player is currently facing.
	private Vector3 m_Velocity = Vector3.zero;

	public bool airControl;

	private void Awake()
	{
		rigidbody2d = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		isOnGround = false;

		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		// This can be done using layers instead but Sample Assets will not overwrite your project settings.
		Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, k_GroundedRadius, whatIsGround);

		for (int i = 0; i < colliders.Length; i++)
			if (colliders[i].gameObject != gameObject)
				isOnGround = true;
	}


	public void Move(float move, bool jump)
	{
		//only control the player if grounded or airControl is turned on
		if (isOnGround || airControl)
		{
			// Move the character by finding the target velocity
			Vector3 targetVelocity = new Vector2(move * 10f, rigidbody2d.velocity.y);
			// And then smoothing it out and applying it to the character
			rigidbody2d.velocity = Vector3.SmoothDamp(rigidbody2d.velocity, targetVelocity, ref m_Velocity, movementSmooth);

			// If the input is moving the player right and the player is facing left...
			if (move > 0 && !facingRight)
			{
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (move < 0 && facingRight)
			{
				// ... flip the player.
				Flip();
			}
		}
		// If the player should jump...
		if (isOnGround && jump)
		{
			// Add a vertical force to the player.
			isOnGround = false;
			rigidbody2d.AddForce(new Vector2(0f, jumpForce));
		}
	}


	private void Flip()
	{
		facingRight = !facingRight;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
