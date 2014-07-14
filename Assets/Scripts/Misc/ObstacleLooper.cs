using UnityEngine;
using System.Collections.Generic;

public class ObstacleLooper : MonoBehaviour
{
    #region Fields
    public GameManager gameManager;

    private float minHeight = -1f;
    private float maxHeight = 1f;
    private int listLocation = -1;
    #endregion


    #region Start
    void Start()
    {

    }
    #endregion 


    #region OnTriggerEnter
    void OnTriggerEnter2D(Collider2D collider)
    {

        Vector2 pos = collider.transform.position;

        // Logic to move the pipes based on their collider size.
        if (collider.tag == "Obstacle")
        {

            collider.gameObject.SetActive(false);

            gameManager.obstacleManager.liveObstacles.RemoveAt(0);
            gameManager.obstacleManager.liveObstacles.Add(gameManager.obstacleCache.ChangeObstacle());

            

            //gameManager.obstacleManager.RandomObstacle(pos.x);

            float widthOfObject = ((BoxCollider2D)collider).size.x;
            //gameManager.obstacleCache.ChangeObstacle();

            
            // Take the size of the collider and move it six times 
            // (Current number of obstacles).
            pos.y = Random.Range(minHeight, maxHeight);
            pos.x += widthOfObject * gameManager.obstacles.Count;

            gameManager.obstacleManager.liveObstacles[5].transform.position = pos;
            //collider.transform.position = pos;
        }

        // Floor panels need to be moved off of their object scale due to being 
        // resized and the collider does not take this into account.
        else
        {
            float widthOfObject = collider.gameObject.transform.localScale.x;

            // Take the size of the collider and move it six times 
            // (Current number of obstacles).
            pos.x += widthOfObject * gameManager.obstacles.Count;

            collider.transform.position = pos;
        }
    }
    #endregion
}
