using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Target"))
        {
            print("Hit " + other.gameObject.name);
            GameObject.Find("ScoreManager").GetComponent<ScoreManager>().AddPoint();
            GameObject.Find(other.gameObject.name).GetComponent<EnemyBehavior>().Shoot();
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Player"))
        {
            print("Hit " + other.gameObject.name);
            GameObject.Find("ScoreManager").GetComponent<ScoreManager>().LosePoint();
            Destroy(gameObject);
        }
    }
}