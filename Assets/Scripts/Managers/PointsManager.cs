using UnityEngine;
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
        }
    }
    #endregion

    public void NearMissBonus()
    {
        //Applies the bonus to the score
        playerScore += 100;
        //Snaps the text colour to green to indicate a bonus
        GUIScore.color = Color.green;
    }
}
