using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Controller : MonoBehaviour
{
    [SerializeField] float speed = 0.0000000003f;
    [SerializeField] float RotateSpeed = 50f;

    private Rigidbody selfRigidbody;
    // Start is called before the first frame update

    // Update is called once per frame
    private void Start()
    {
        selfRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0,0, speed * Time.deltaTime);
            //selfRigidbody.position += new Vector3(0, 0, speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0,0, -speed * Time.deltaTime);
            //selfRigidbody.position += new Vector3(0,0, -speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            //selfRigidbody.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            //selfRigidbody.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
        
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0,-RotateSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0,RotateSpeed * Time.deltaTime, 0);
        }
        
    }
}
