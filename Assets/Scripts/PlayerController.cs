using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private float horizontal;
	private float speed = 8f;
	private float jumpingPower = 16f;
	private bool isFacingRight = false;
	private bool isFacingLeft = false;
	private bool isGrounded = false;

	[SerializeField] private Rigidbody2D rb;
	[SerializeField] private Transform groundCheck;
	[SerializeField] private LayerMask groundLayer;
	[SerializeField] private Animator anim;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		anim = gameObject.GetComponent<Animator>();
	}

	void Update()
	{
		horizontal = Input.GetAxisRaw("Horizontal");

		anim.SetFloat("Speed", Mathf.Abs(horizontal));
		anim.SetBool("FacingL", isFacingLeft);
		anim.SetBool("FacingR", isFacingRight);
		anim.SetBool("GroundCheck", isGrounded);

		if (horizontal >= 0.1f) isFacingRight = true;
		else isFacingRight = false;

		if (horizontal <= -0.1f) isFacingLeft = true;
		else isFacingLeft = false;

		if (IsGrounded()) isGrounded = true;
		else isGrounded = false;

		/*
        // Overall Jump Mechanic
        // Jump Hold Mechanic - not used
		if (Input.GetButtonDown("Jump") && IsGrounded())
		{
			rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
		}
		
		// Jump Release Mechanic - not used
		if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
		{
			rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
		}
		*/
			//Flip();
	}

    private void FixedUpdate()
	{
		rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
	}

	private bool IsGrounded()
	{
		return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
	}

	/*
	// Flip Sprite when moving to a certain direction
	private void Flip()
	{
		if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
		{
			isFacingRight = !isFacingRight;
			Vector3 localScale = transform.localScale;
			localScale.x *= -1f;
			transform.localScale = localScale;
		}
	}
	*/
}
