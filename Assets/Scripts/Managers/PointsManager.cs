using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PointsManager : MonoBehaviour
{
    #region Fields
    //Placeholder
    public Transform player;
    public GUIText GUIScore;
    public List<GameObject> nearMissTexts;
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

    #region FixedUpdate
    void FixedUpdate()
    {
        //If the game is still running
        if (gameManager.isDead == false)
        {
            //Increases the score
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

            //Sets the score display text
            GUIScore.text = ("Score: " + playerScore.ToString());
            playerScoreEnd.text = ("Your Score: " + playerScore.ToString());
            highScoreEnd.text = ("High Score: " + highScore.ToString());

            //Constantly lerping the colour to black
            GUIScore.color = Color.Lerp(GUIScore.color, Color.black, Time.deltaTime);

            //Updates all active NearMiss messages
            foreach(GameObject go in nearMissTexts)
            {
                if (go.activeSelf)
                {
                    //Gets the screenPosition of the NearMiss message
                    Vector2 screenPosition = Camera.main.WorldToViewportPoint(go.transform.position);

                    //If the GO has fallen off screen, deactivate it.
                    //Otherwise, position the child GUIText
                    if (screenPosition.x < 0)
                        go.SetActive(false);
                    else
                        go.transform.GetChild(0).transform.position = screenPosition;

                    //The parent object is for world space, whereas the child object with the GUIText
                    //is for viewport space (Incase you get confused)
                }
            }
        }
    }
    #endregion

    #region NearMissBonus
    public void NearMissBonus()
    {
        //Applies the bonus to the score
        playerScore += 50;
        //Snaps the text colour to green to indicate a bonus
        GUIScore.color = Color.green;

        //Finds an inactive NearMiss message to use
        for(int i = 0; i < nearMissTexts.Count; i++)
        {
            if(!nearMissTexts[i].activeSelf)
            {
                //Positions it near the player and activates it
                nearMissTexts[i].transform.position = player.position;
                nearMissTexts[i].gameObject.SetActive(true);
                break;
            }
        }
    }
    #endregion
}
