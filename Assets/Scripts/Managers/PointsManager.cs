﻿using UnityEngine;
using System.Collections;

public class PointsManager : MonoBehaviour
{
    #region Fields
    //Placeholder
    public Transform player;
    public GUIText GUIScore;
    public GUIText playerScoreEnd;
    public GUIText highScoreEnd;
    public GameManager gameManager;
    public GameObject highScoreDisplay;
    
    private int playerScore;
    private int highScore;
    private float timer;
    #endregion


    #region Start
    void Start()
    {
        // Get High Score.
        highScore = PlayerPrefs.GetInt("highScore", 0);
    }
    #endregion 

    #region OnDestroy
    void OnDestroy()
    {
        // Store HighScore.
        PlayerPrefs.SetInt("highScore", highScore);
    }
    #endregion 

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameManager.isDead == false)
        {
            timer += Time.deltaTime;
            if (timer > 0)
            {
                playerScore++;
                timer = 0;
            }

            // Update the high score.
            if (playerScore >= highScore)
            {
                highScore = playerScore;
            }

            GUIScore.text = ("Score: " + playerScore.ToString());
            playerScoreEnd.text = ("Your Score: " + playerScore.ToString());
            highScoreEnd.text = ("High Score: " + highScore.ToString());
        }
    }
}
