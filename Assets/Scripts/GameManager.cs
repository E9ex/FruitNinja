using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score;

    private void Start()
    {
        newgame();
    }

    void newgame()
    {
        score = 0;
        scoreText.text = "Score: "+score.ToString();
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = "Score: "+score.ToString();
    }

}
