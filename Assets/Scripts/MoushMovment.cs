using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoushMovment : MonoBehaviour
{

    public float mouseSensitivity =500f; 

    float xRotation = 0f; 
    float yRotation = 0f; 

   public float topClamp = -90f; 
   public float bottomClamp = 90f; 

    // Start is called before the first frame update
    void Start()
    {
        // Lock the cursor to middle of the screen and making it invisible
        Cursor.lockState = CursorLockMode.Locked; 
    }

    // Update is called once per frame
    void Update()
    {
        // Getting the moush inputs 
        float moushX =Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float moushY =Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotation around the x axis (Look Up and Down)
        xRotation -= moushY; 

        //Clamp the rotation (if look to up dont make a flip)
        xRotation = Mathf.Clamp(xRotation, topClamp, bottomClamp); 

        // Rotation around the y axis (Look left and right)
        yRotation += moushX; 

        //Apply rotations to our transform 
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f); 



    }
}
