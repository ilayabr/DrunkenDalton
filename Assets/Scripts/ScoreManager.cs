using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private TMP_Text text;
    private int score;

    void Start()
    {
        text = GameObject.Find("score").GetComponent<TMP_Text>();
    }

    public void AddPoint()
    {
        score++;
        text.text = "score = " + score;
    }

    public void LosePoint()
    {
        score--;
        text.text = "score = " + score;
    }
}