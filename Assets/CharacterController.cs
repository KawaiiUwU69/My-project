using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FirstPersonMovement : MonoBehaviour

{

    public CharacterController controller;

    public float speed = 12f;

    public float gravity = -9.81f;

    public float jumpHeight = 3f;



    public Transform groundCheck;

    public float groundDistance = 0.4f;

    public LayerMask groundMask;



    Vector3 velocity;

    bool isGrounded;



    void Update()

    {

        // Check if the player is grounded

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);



        // If grounded and velocity is downward, reset velocity

        if (isGrounded && velocity.y < 0)

        {

            velocity.y = -2f;

        }



        // Input for movement

        float x = Input.GetAxis("Horizontal");

        float z = Input.GetAxis("Vertical");



        // Move the player

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);



        // Jumping logic

        if (Input.GetButtonDown("Jump") && isGrounded)

        {

            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        }



        // Apply gravity to the player

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }

}