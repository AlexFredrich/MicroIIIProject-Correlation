using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    //SerialeFields for editing
    //Player movement speed
    [SerializeField] float speed = 5f;
    //Player jumpp height
    [SerializeField] float jumpHeight = 5f;
    //To check if the player is on the ground
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    float groundRadius;
    [SerializeField]
    private LayerMask whatIsGround;
    //Player identification string
    [SerializeField] string playerID = "P1";

    //private fields
    //Horizontal input
    float horizontalInput;
    //Vertical input
    float verticalInput;
    //Player rigidbody
    Rigidbody2D rigidbody;
    //Name of the horizontal axis
    string horizontalAxis;
    //Name of the vertical axis
    string verticalAxis;
    private bool grounded;
    private bool pressedButton;

	// Use this for initialization
	void Start ()
    {
        //Set the axis and buttons names to allow the code to work for both players
        horizontalAxis = string.Format("{0}-Horizontal", playerID);
        verticalAxis = string.Format("{0}-Vertical", playerID);

        //Getting reference to the rigidbody
        rigidbody = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {
        Move();
        UpdateIsOnGround();
        Jump();
	}

    private void UpdateIsOnGround()
    {

        Collider2D[] groundColliders = Physics2D.OverlapCircleAll(groundCheck.position, groundRadius, whatIsGround);
        grounded = groundColliders.Length > 0;
    }
    
    //Checking the input and moving the player
    private void Move()
    {
        horizontalInput = Input.GetAxis(horizontalAxis);
        
        rigidbody.velocity = new Vector2(horizontalInput * speed * Time.deltaTime, rigidbody.velocity.y);
    }

    private void Jump()
    {
        //verticalInput = Input.GetAxis(verticalAxis);
        pressedButton = Input.GetButtonUp(verticalAxis);
        if(pressedButton && grounded)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpHeight * Time.deltaTime);
        }

    }
}
