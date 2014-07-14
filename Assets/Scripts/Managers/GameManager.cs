﻿using UnityEngine;
using System.Collections.Generic;

public class GameManager: MonoBehaviour
{

    #region Fields 
    public List<Transform> obstacles = new List<Transform>();
    public GameObject playerExplosion;
    public Transform player;
    [HideInInspector]
    public bool isDead = false;
    [HideInInspector]
    public int playCount = 0;

    // Objects for each of the manager classes
    public ButtonManager buttonManager;
    public PlayerManager playerManager;
    public AudioManager audioManager;
    public PointsManager pointsManager;
    public CamShake camShake;
    public ObstacleManager obstacleManager;
    public ObstacleCache obstacleCache;
    #endregion 

    #region Start
    void Start()
    {
        playCount = PlayerPrefs.GetInt("playCount", 0);
    }
    #endregion

    #region Update 
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft)
            Screen.orientation = ScreenOrientation.LandscapeLeft;
        else if (Input.deviceOrientation == DeviceOrientation.LandscapeRight)
            Screen.orientation = ScreenOrientation.LandscapeRight;
    }
    #endregion

    #region TriggerCollision
    public void TriggerCollision()
    {
        // Set location of particle effect to be the players last location.
        playerExplosion.transform.localPosition = player.transform.localPosition;
        // Play the explosion.
        playerExplosion.SetActive(true);
    }
    #endregion

    #region OnDestroy
    void OnDestroy()
    {
        PlayerPrefs.SetInt("playCount", playCount);
    }
    #endregion
}
