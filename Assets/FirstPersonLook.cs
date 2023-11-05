using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FirstPersonLook : MonoBehaviour

{

    public float mouseSensitivity = 100f;

    public Transform playerBody;

    private float xRotation = 0f;



    void Start()

    {

        // Optionally, hide the cursor during gameplay

        Cursor.lockState = CursorLockMode.Locked;

    }



    void Update()

    {

        // Get the mouse input

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;



        // Apply the rotation for looking up and down

        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Clamping the rotation



        // Apply the rotation to the camera (for pitch)

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);



        // Apply the rotation to the player body (for yaw)

        playerBody.Rotate(Vector3.up * mouseX);

    }

}

