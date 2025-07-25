﻿using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject m_Player;

    [SerializeField]
    public Joystick joystick;
    [SerializeField]
    private Rigidbody2D rb;
    private Animator animator;
    [SerializeField]
    private int Speed = 400;
    [SerializeField]
    private float moveThreshold = 0.02f;


    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.1f;
    private bool isGrounded;
    private bool jumpTriggered = false;

    private BoxCollider2D boxCollider;
    private Vector2 boxColliderSize;
    private Vector2 boxColliderOffset;


    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        boxCollider = GetComponentInChildren<BoxCollider2D>();
        boxColliderSize = boxCollider.size;
        boxColliderOffset = boxCollider.offset;
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        float jumpForce = Mathf.Lerp(2f, 10f, Mathf.Clamp01(joystick.Vertical));
        Debug.Log("Grounded: " + isGrounded);

        if (isGrounded && animator.GetBool("isJumping"))
            animator.SetBool("isJumping", false);

         if (joystick.Vertical > 0.5f && isGrounded && !jumpTriggered)
        {
            Jump(jumpForce);
            jumpTriggered = true;
        }

        if (joystick.Vertical <= 0.1f)
            jumpTriggered = false;


        if (joystick.Vertical < -0.5f && isGrounded)
        {
            animator.SetBool("isCrouchin", true);
            ChangeColider(new Vector2(1f , 0.5f), new Vector2(0f , -0.72f));
        }
        else
        {
            animator.SetBool("isCrouchin", false);
            ChangeColider(boxColliderSize, boxColliderOffset);
        }

    }

    void FixedUpdate()
    {
        float moveInput = joystick.Horizontal;
        Vector2 input = new Vector2(moveInput, 0);

        print(moveInput);

        if (isGrounded)
        {
            animator.SetFloat("Speed", Mathf.Abs(moveInput));
        }

        rb.linearVelocity = new Vector2(moveInput * Speed * Time.deltaTime, rb.linearVelocity.y);

        if (moveInput > moveThreshold)
        {
            m_Player.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (moveInput < -moveThreshold)
        {
            m_Player.gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    public void Jump(float jumpForce)
    {
        animator.SetBool("isJumping", true);
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }

    private void ChangeColider(Vector2 newColliderSize, Vector2 newColliderOffset)
    {
        boxCollider.size = newColliderSize;
        boxCollider.offset = newColliderOffset;
    }

}