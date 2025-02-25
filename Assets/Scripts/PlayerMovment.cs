using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovment : MonoBehaviour
{
    private CharacterController controller;
    public float speed = 8f;
    public float gravity = -9.81f * 2;
    [SerializeField] private Slider stamina;
    [SerializeField] private Slider iFrameDisplay;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;

    private bool isGrounded;
    private bool isInvincible = false;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Ground check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        //Resseting the default velocity 
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");


        //creating the moving vector 
        Vector3 move = transform.right * x + transform.forward * z; // (right - red axis, forward - blue axis )

        // Acrually moving the player 
        controller.Move(move * (speed * Time.deltaTime));

        //Falling down 
        velocity.y += gravity * Time.deltaTime;

        //Exctuting the jump 
        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && stamina.value >= 2f)
        {
            stamina.value -= 2f;
            StartCoroutine(IFrames());
            controller.Move(move * (speed * 75 * Time.deltaTime));
        }

        stamina.value += 0.001f;
    }

    private void FixedUpdate()
    {
        iFrameDisplay.value -= 0.05f;
    }

    IEnumerator IFrames()
    {
        isInvincible = true;
        iFrameDisplay.value += 1f;
        yield return new WaitForSeconds(1);
        isInvincible = false;
    }

    public bool getIsInvincible()
    {
        return isInvincible;
    }
}