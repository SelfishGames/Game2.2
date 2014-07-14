using UnityEngine;
using System.Collections;

public class TutorialScript : MonoBehaviour
{
    #region Fields
    public Transform targetObstacle;
    public GameObject[] hintMessage;
    public GameManager gameManager;
    public GameObject[] emmiters;
    public GameObject player;

    private float t = 0;

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
        if (transform.localPosition.x >= targetObstacle.transform.localPosition.x - 2)
        {
            // Pause the player and each particle system.
            StopStartPlayer(0, 0);
            // Display the first hint message. 
            hintMessage[0].SetActive(true);
            // Allow the player to move the obstacles.
            gameManager.isDead = false;

            // If the obstacle has been moved to the correct position. 
            if (targetObstacle.transform.localPosition.y >= -0.1f && targetObstacle.transform.localPosition.y <= 0.1f)
            {
                // Return movement to player and the particles.
                StopStartPlayer(3, 1);
                // Stop the player moving obstacles.
                gameManager.isDead = true;
                // Remove first message.
                hintMessage[0].SetActive(false);
                hintMessage[1].SetActive(true);
            }
        }

        if (transform.localPosition.x >= 11.8f)
        {
            hintMessage[1].SetActive(false);
            hintMessage[2].SetActive(true);
            gameManager.playCount = 1;
        }
    }
    #endregion

    #region StopStartPlayer
    void StopStartPlayer(int player, int emitter)
    {
        // Alter speed of player and emmiter rate.
        gameManager.playerManager.speed = player;
        foreach (GameObject emit in emmiters)
        {
            emit.particleSystem.playbackSpeed = emitter;
        }
    }
    #endregion
}
