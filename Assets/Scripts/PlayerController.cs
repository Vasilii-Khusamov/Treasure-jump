using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private Rigidbody2D rigitBody2D;
	SpriteRenderer spriteRenderer;
	Animator playerAnimator;
    [SerializeField] float speed = 100f;
	[SerializeField] float jumpForce = 20f;
	[SerializeField] float groundFriction = 0.5f;
	[SerializeField] float airFriction = 0.1f;
    private bool isJumping = false;
	private bool isGrounded = true;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		rigitBody2D = gameObject.GetComponent<Rigidbody2D>();
		spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
		playerAnimator = gameObject.GetComponentInChildren<Animator>();
    }

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
		{
			isJumping = true;
		}
	}
	// Update is called once per frame
	void FixedUpdate()
    {
        SetAnimation();

        float newVelocityX = 0;
        if (Input.GetKey(KeyCode.A))
        {
            newVelocityX += -speed * Time.fixedDeltaTime;
            spriteRenderer.flipX = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            newVelocityX += speed * Time.fixedDeltaTime;
            spriteRenderer.flipX = false;
        }

        rigitBody2D.linearVelocityX = Mathf.Lerp(newVelocityX, rigitBody2D.linearVelocityX, 1 - GetFriction());
        if (isJumping)
        {
            rigitBody2D.linearVelocityY = jumpForce;
            isJumping = false;
        }
    }


    void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.CompareTag("Ground"))
		{
			isGrounded = true;
		}
	}
	void OnTriggerExit2D(Collider2D collider)
	{
		if (collider.gameObject.CompareTag("Ground"))
		{
			isGrounded = false;
		}
	}
	private float GetFriction()
	{
		if (isGrounded)
		{
			return groundFriction;
		}
		else
		{
			return airFriction;
		}
	}
    private void SetAnimation()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            playerAnimator.SetBool("IsRunning", true);
        }
        else
        {
            playerAnimator.SetBool("IsRunning", false);
        }
        if (!isGrounded && rigitBody2D.linearVelocityY > 0)
        {
            playerAnimator.SetBool("IsJumping", true);
            playerAnimator.SetBool("IsFalling", false);
        }
        else if (!isGrounded && rigitBody2D.linearVelocityY <= 0)
        {
            playerAnimator.SetBool("IsJumping", false);
            playerAnimator.SetBool("IsFalling", true);
        }
        else
        {
            playerAnimator.SetBool("IsJumping", false);
            playerAnimator.SetBool("IsFalling", false);
        }
    }
}
