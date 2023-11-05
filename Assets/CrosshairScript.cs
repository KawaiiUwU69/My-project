using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;



public class CrosshairController : MonoBehaviour

{

    public Image crosshairImage; // Assign this in the inspector

    public Color defaultColor = Color.white; // Assign this in the inspector

    public Color interactiveColor = Color.red; // Assign this in the inspector

    public LayerMask interactiveLayer; // Set this in the inspector

    public float rayLength = 100f;



    private Camera cam;



    void Start()

    {

        cam = Camera.main; // Cache the main camera
        crosshairImage.color = defaultColor;
    }



    void Update()

    {

        RaycastHit hit;

        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));



        // Change the sprite of the crosshair based on if you hit something interactive

        if (Physics.Raycast(ray, out hit, rayLength, interactiveLayer))

        {

            // Change to interactive crosshair

            crosshairImage.color = interactiveColor;

        }

        else

        {

            // Change back to default crosshair

            crosshairImage.color = defaultColor;
        }

    }

}