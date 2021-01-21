using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float movementDirection;

    public float movementSpeed = 5.0f;
    public float jumpForce = 10.0f;

    private bool isFacingRight = true;
    private bool isJumping = false;

    public bool isGrounded;

    private Rigidbody2D rb;

    public Animator PlayerAnimator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        movementDirection = Input.GetAxisRaw("Horizontal");
        PlayerAnimator.SetFloat("PlayerSpeed", Mathf.Abs(movementDirection * movementSpeed));
        Flip();

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
            PlayerAnimator.SetBool("Jumping", true);
        } 
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementDirection, 0f, 0f);
        transform.position += movement * Time.fixedDeltaTime * movementSpeed;

        if (isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = false;
        }
    }

    void Flip()
    {
        if ((isFacingRight && movementDirection < 0) || (!isFacingRight && movementDirection > 0))
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;

            isFacingRight = !isFacingRight;
        } 
        
    }

}
