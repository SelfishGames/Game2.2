using UnityEngine;
using System.Collections;

public class TutorialScript : MonoBehaviour
{
    #region Fields
    public Transform targetObstacle;
    public GameObject[] hintMessage;
    public GameManager gameManager;
    public GameObject[] emitters;
    public GameObject player;
    #endregion

    #region Start
    void Start()
    {
        gameManager.isDead = true;
    }
    #endregion

    #region Update
    void Update()
    {
        // If we hit the first checkpoint.
        if (transform.localPosition.x >= targetObstacle.transform.position.x + 6)
        {
            // Pause the player and each particle system.
            StopStartPlayer(0, 0);
            // Allow the player to move the obstacles.
            gameManager.isDead = false;
            // Display the first hint message.
#if UNITY_ANDROID
            hintMessage[0].SetActive(true);
#endif

#if UNITY_WEBPLAYER
            hintMessage[3].SetActive(true);
#endif
            

            // If the obstacle has been moved to the correct position.
            if (targetObstacle.transform.localPosition.y >= 0.8f && targetObstacle.transform.localPosition.y <= 0.9f)
            {
                // Return movement to player and the particles.
                StopStartPlayer(3, 1);
                // Stop the player moving obstacles.
                gameManager.isDead = true;
                // Remove first message.
                hintMessage[0].SetActive(false);
                hintMessage[3].SetActive(false);
                hintMessage[1].SetActive(true);
            }
        }

        if (transform.localPosition.x >= 11.65f)
        {
            hintMessage[1].SetActive(false);
#if UNITY_ANDROID
            hintMessage[2].SetActive(true);
#endif

#if UNITY_WEBPLAYER
            hintMessage[4].SetActive(true);
#endif
            gameManager.playCount = 1;
        }
    }
    #endregion

    #region StopStartPlayer
    void StopStartPlayer(int player, int emitter)
    {
        // Alter speed of player and emitter rate.
        gameManager.playerManager.speed = player;
        foreach (GameObject emit in emitters)
        {
            emit.particleSystem.playbackSpeed = emitter;
        }
    }
    #endregion
}
