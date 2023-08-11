using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
	Rigidbody2D playerRB;
	playerController controller;
	Animator animator;

	[SerializeField] float runSpeed = 40f;
	[SerializeField] float climbSpeed = 1f;

	
	float horizontalMove = 0f;
	float verticalMove = 0f;

	int posX;

	bool jump = false;
	bool crouch = false;
	bool isClimb = false;
	bool canClimb = false;
	bool canMove = true;

	public bool SetCanClimb { set { canClimb = value; } }
	public bool SetCanMove { set { canMove = value; } }

	private void Awake()
    {
		playerRB = GetComponent<Rigidbody2D>();
		controller = GetComponent<playerController>();
		animator = GetComponent<Animator>();
	}

    void Update()
	{
		if (canMove)
        {
			if(canClimb && Input.GetKeyDown(KeyCode.Z))
            {
				isClimb = true;
				posX = (int)transform.position.x;
				float adjuste = 0.50f;
				if(posX < 0)
                {
					adjuste *= -1;
                }
                transform.position = new Vector2((float)posX + adjuste, transform.position.y);
			}
			horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
			animator.SetFloat("moveSpeed", Mathf.Abs(horizontalMove));
			animator.SetFloat("verticalVelocity", playerRB.velocity.y);
			animator.SetBool("isClimb", isClimb);

			if(isClimb)
            {
				verticalMove = Input.GetAxisRaw("Vertical") * climbSpeed;
				animator.SetFloat("climbSpeed", Mathf.Abs(verticalMove));

				if(Input.GetButtonDown("Jump") || !canClimb || playerInventory.InstanceInventory.IsTakeDamage)
                {
					isClimb = false;
				}
			}
            else
            {
				if (Input.GetButtonDown("Jump"))
				{
					jump = true;
				}

				if (Input.GetButtonDown("Crouch"))
				{
					crouch = true;
				}
				else if (Input.GetButtonUp("Crouch"))
				{
					crouch = false;
				}
			}
			
		}
	}


    public void OnLand(bool isGround)
    {
        animator.SetBool("isGround", isGround);
    }

    public void OnCrouch(bool isCrouch)
    {
        animator.SetBool("isCrunch", isCrouch);
    }

    void FixedUpdate()
	{
		// Move our character
		if(isClimb)
		{
			controller.Climb(verticalMove);
		}
		else
		{
			controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		}
		jump = false;
	}


	public void setAnimatorDamage(bool damage)
    {
		animator.SetBool("takeDamage", damage);
	}
}
