using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    //public CharacterController controller;
    public float gravity = -9.81f;

    public float speed = 5f;


    public float walkspeed = 5;
    public float sprintSpeed = 8f;
    public float sprintingSpeed = 12f;
    public float jumpHeight = 3f;


    //movement 
    KeyCode codes;
    public float startTime;
    //Jump setting

     public float fallMultiplier = 2.5f;
     public float lowJumpMultiplier = 2f;


    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    Vector3 lastMoveDir;



    private void Start()
    {
        rb = GetComponent<Rigidbody>();   
    }
    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded & velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //Input
        float x = Input.GetAxisRaw("Horizontal") * speed;
        float y = Input.GetAxisRaw("Vertical") * speed;


        //Movement

        Vector3 movePos = transform.right * x + transform.forward * y;
        Vector3 newMovePos = new Vector3(movePos.x, rb.velocity.y, movePos.z);
        rb.velocity = newMovePos;
 
        //controller.Move(movePos * speed * Time.deltaTime);

        //velocity.y += gravity*2 * Time.deltaTime;
        //controller.Move(velocity * Time.deltaTime);


        //if (Input.GetButtonDown("Jump") && isGrounded)
        //{
        //    velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        //}

        if (Input.GetKey(KeyCode.LeftShift))
        {

            speed = sprintSpeed;
        }
        else
        {
            speed = walkspeed;
        }

        #region rb code
        switch (codes)
        {

            case KeyCode.W:
                startTime = Time.time;
                if (startTime < 2f)
                {
                    speed = sprintingSpeed;
                }
                if (Input.GetKeyUp(KeyCode.W))
                {
                    float timePressed = Time.time - startTime;
                }
                break;
            case KeyCode.S:
                startTime = Time.time;
                break;
            case KeyCode.D:
                startTime = Time.time;
                break;
            case KeyCode.A:
                startTime = Time.time;
                break;
        }
        //Adjusitng the fall multiplier for better jumps


        if (Input.GetButtonDown("Jump") && isGrounded)
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpHeight, rb.velocity.y);
            }


        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {

            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
        #endregion


        //lastMoveDir = move;
        //HandleDash();

    }

   //private void HandleDash()
   // {
   //     if(Input.GetKeyDown(KeyCode.LeftShift))
   //     {
   //             transform.position += lastMoveDir * dashDistance;
   //     }
   // }
}
