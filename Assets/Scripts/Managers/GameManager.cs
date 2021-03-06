using UnityEngine;
using System.Collections.Generic;

public class GameManager: MonoBehaviour
{
    #region Fields
    public List<Transform> obstacles = new List<Transform>();
    public GameObject playerExplosion;
    public Transform player;
    public bool collided = false;
    //[HideInInspector]
    public bool isDead = false;
    [HideInInspector]
    public bool visibleSlider = false;
    //[HideInInspector]
    public int playCount;
    //[HideInInspector]
    public int touchCount;
    //[HideInInspector]
    public bool activeAd = false;
    public GameObject gameTitle;
    public GameObject credits;
    public GameObject challengeBoard;
    public GUIText challengeText;

    public int totalGamesPlayed;

    // Objects for each of the manager classes
    public ButtonManager buttonManager;
    public PlayerManager playerManager;
    public AudioManager audioManager;
    public PointsManager pointsManager;
    public CamShake camShake;
    public ObstacleManager obstacleManager;
    public ObstacleCache obstacleCache;
    public LoopMusic loopMusic;
    public CreditManager creditManager;
    #endregion

    #region Start
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        playCount = 0;
        touchCount = 0;
        playCount = PlayerPrefs.GetInt("playCount", 0);

        totalGamesPlayed = PlayerPrefs.GetInt("totalGamesPlayed");
    }
    #endregion

    #region Update
    void Update()
    {
        //Quit the game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        //Sets the game orientation based on the phone orientation
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

        totalGamesPlayed++;
        PlayerPrefs.SetInt("totalGamesPlayed", totalGamesPlayed);
    }
    #endregion
}
