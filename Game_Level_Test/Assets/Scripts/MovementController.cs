using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovementController : MonoBehaviour
{
	public float jumpForce = 400f;
	[Range(0, .3f)] public float movementSmooth = .05f;

	public LayerMask whatIsGround;
	public Transform groundCheck;


	const float k_GroundedRadius = .2f;
	private bool isOnGround;

	private Rigidbody2D rigidbody2d;
	private bool facingRight = true;
	private Vector3 m_Velocity = Vector3.zero;

	public bool airControl;

	private void Awake()
	{
		rigidbody2d = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		isOnGround = false;

		Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, k_GroundedRadius, whatIsGround);

		for (int i = 0; i < colliders.Length; i++)
			if (colliders[i].gameObject != gameObject)
				isOnGround = true;
	}


	public void Move(float move, bool jump, bool isPLatform)
	{
		if (isOnGround || airControl)
		{
			Vector3 targetVelocity = new Vector2(move * 10f, rigidbody2d.velocity.y);
			rigidbody2d.velocity = Vector3.SmoothDamp(rigidbody2d.velocity, targetVelocity, ref m_Velocity, movementSmooth);

			if (!isPLatform)
			{
				if (move > 0 && !facingRight)
				{
					Flip();
				}
				else if (move < 0 && facingRight)
				{
					Flip();
				}
			}
		}

		if (isOnGround && jump)
		{
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
