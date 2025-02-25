using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Transform Crosshair3D;
    [SerializeField] private TMP_Text scoreText;
    private int score = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Crosshair3D.position), out hit, 1000))
            {
                if (hit.transform.gameObject.CompareTag("Target"))
                {
                    Debug.Log("hit!");
                    score++;
                    scoreText.text = "score = " + score;
                }
            }
        }
    }
}