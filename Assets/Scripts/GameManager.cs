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
    private Blade _blade;
    private Spawner _spawner;


    private void Awake()
    {
        _blade = FindObjectOfType<Blade>();
        _spawner = FindObjectOfType<Spawner>();
    }

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

    public void explode()
    {
        _blade.enabled = false;
        _spawner.enabled = false;
        

    }

}
