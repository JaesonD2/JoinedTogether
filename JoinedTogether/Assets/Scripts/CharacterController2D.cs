using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class CharacterController2D : MonoBehaviour
{
	[SerializeField] private float m_JumpForce = 400f;							// Amount of force added when the player jumps.
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;	// How much to smooth out the movement
	[SerializeField] private bool m_AirControl = false;							// Whether or not a player can steer while jumping;
	[SerializeField] private LayerMask m_WhatIsGround;							// A mask determining what is ground to the character
	[SerializeField] private Transform m_GroundCheck;							// A position marking where to check if the player is grounded.
	[SerializeField] private Transform m_CeilingCheck;							// A position marking where to check for ceilings

	const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
	private bool m_Grounded;            // Whether or not the player is grounded.
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;  // For determining which way the player is currently facing.
	private Vector3 m_Velocity = Vector3.zero;

	private int coyoteAllowance = 5;
	private int coyoteCount = 5;
	private int jumpBuffer = 5;
	private int jumpBufferAllowance = 5;

	public bool goBackwards = false;
	public bool hasAudio;
	private AudioManager audioManager;

	public Transform mySprite;

	[Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

	private void Awake()
	{
		if (hasAudio)
			audioManager = FindObjectOfType<AudioManager>();

		m_Rigidbody2D = GetComponent<Rigidbody2D>();

		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();
	}

	private void FixedUpdate()
	{
		bool wasGrounded = m_Grounded;
		m_Grounded = false;

		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		// This can be done using layers instead but Sample Assets will not overwrite your project settings.
		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				coyoteCount = 0;
				m_Grounded = true;
				if (!wasGrounded)
                {
					
					OnLandEvent.Invoke();
                }	
			}
		}
	}


	public void Move(float move, bool jump)
	{
		//only control the player if grounded or airControl is turned on
		if (m_Grounded || m_AirControl)
		{
			Vector3 targetVelocity = Vector2.zero;

			// Move the character by finding the target velocity
			if (!goBackwards)
			{
				targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
			}
			else
			{
				targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
			}
			// And then smoothing it out and applying it to the character
			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

			// If the input is moving the player right and the player is facing left...
			if (move > 0 && !m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (move < 0 && m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
		}
		// If the player wants to jump...
		if (jump)
			jumpBuffer = 0; // 4

		if (coyoteCount < coyoteAllowance && jumpBuffer < jumpBufferAllowance)
		{
			if(audioManager != null)
            {
				audioManager.Play("Jump");
            }
			coyoteCount = coyoteAllowance;
			jumpBuffer = jumpBufferAllowance;
			// Add a vertical force to the player.
			m_Grounded = false;
			m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, 0);
			if (goBackwards)
            {
				m_Rigidbody2D.AddForce(new Vector2(0f, -m_JumpForce));
			}
			else
            {
				m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
			}
		}
		coyoteCount++;
		jumpBuffer++;
	}


	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
