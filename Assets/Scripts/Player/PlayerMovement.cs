using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 5f;
    public float walkspeed = 5;
    public float sprintSpeed = 8f;
    public float sprintingSpeed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float _dashTime = 0.30f;
    //public float _dashSpeed = 60f;
    //public float dashDistance = 10f;


    //movement 
    KeyCode codes;
   public  float startTime;
    //Jump setting 
    
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float jVelocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    //Vector3 lastMoveDir;



    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded & velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        //walking & Sprinting 
        controller.Move(move * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Debug.Log("Sprinting");
            speed = sprintSpeed;
        }
        else
        {
            speed = walkspeed;
        }


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
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

      
        if (velocity.y < 0)
        {
            velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (velocity.y > 0 && !Input.GetButton("Jump"))
        {

            velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

     velocity.y += gravity * 2 * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

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
