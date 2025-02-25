using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinityLoopMovement : MonoBehaviour
{
    public float speed = 0.5f; // Speed of movement along the curve
    private float t;
    private Vector3 localStartPosition; // Local position relative to the camera

    void Start()
    {
        localStartPosition = transform.localPosition; // Store initial local position
        t = -12 * Mathf.PI; // Start at the lower bound
    }

    void Update()
    {
        t += speed * Time.deltaTime; // Increment t over time

        // Define the parametric equations
        float x = Mathf.Cos(t);
        float y = Mathf.Sin(t) * Mathf.Cos(t);

        // Update the object's local position relative to the camera
        transform.localPosition = localStartPosition + new Vector3(x, y, 0);

        // Stop movement if t exceeds the upper bound
        if (t > 32 * Mathf.PI)
        {
            enabled = false; // Disable the script
        }
    }
}