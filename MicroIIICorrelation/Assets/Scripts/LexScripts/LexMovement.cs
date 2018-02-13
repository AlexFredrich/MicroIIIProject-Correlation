using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LexMovement : MonoBehaviour
{
    #region Editor fields
    [SerializeField]
    private float speed = 8;

    [SerializeField] string playerID = "P1";

    [SerializeField]
    private float jumpHeight = 6;

    [SerializeField]
    private float groundCheckRadius = 0.35f;

    [SerializeField]
    private Transform groundCheckPosition;

    [SerializeField]
    private LayerMask whatIsGround;
    #endregion

    #region private fields
    private bool isOnGround;
    private float horizontalInput;
    private Rigidbody2D myRigidbody2D;
    private bool pressedJump;
    #endregion
    private AudioSource audioSource;
    string horizontalAxis;
    //Name of the vertical axis
    string verticalAxis;
    private void UpdateIsOnGround()

    {
        Collider2D[] groundColliders =
             Physics2D.OverlapCircleAll(groundCheckPosition.position, groundCheckRadius, whatIsGround);

        isOnGround = groundColliders.Length > 0;
    }

    // Use this for initialization
    void Start()
    {
        horizontalAxis = string.Format("{0}-Horizontal", playerID);
        verticalAxis = string.Format("{0}-Vertical", playerID);
        myRigidbody2D = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        GetMovementInput();
        GetJumpInput();
        UpdateIsOnGround();
    }

    private void GetJumpInput()
    {
        pressedJump = Input.GetButtonDown("Jump");
    }

    private void FixedUpdate()
    {
        HandlePlayerMovement();
        HandleJump();
    }

    private void HandleJump()
    {
        if (pressedJump && isOnGround)
        {
            myRigidbody2D.velocity =
                new Vector2(myRigidbody2D.velocity.x, jumpHeight);
            audioSource.Play();

            isOnGround = false;
        }
    }

    private void GetMovementInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
    }

    private void HandlePlayerMovement()
    {
        myRigidbody2D.velocity =
            new Vector2(speed * horizontalInput, myRigidbody2D.velocity.y);
    }
}
