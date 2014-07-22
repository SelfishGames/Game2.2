using UnityEngine;
using System.Collections.Generic;

public class ObstacleLooper : MonoBehaviour
{
    #region Fields
    public GameManager gameManager;

    private float minHeight = -1f;
    private float maxHeight = 1f;
    private int[] startRotation = { 0, 180 };
    #endregion

    #region OnTriggerEnter
    void OnTriggerEnter2D(Collider2D collider)
    {
        Vector2 pos = collider.transform.position;

        // Logic to move the pipes based on their collider size.
        if (collider.tag == "Obstacle")
        {
            int rand = Random.Range(0, 2);
            collider.gameObject.SetActive(false);

            gameManager.obstacleManager.liveObstacles.RemoveAt(0);
            gameManager.obstacleManager.liveObstacles.Add(gameManager.obstacleCache.ChangeObstacle());
            
            float widthOfObject = ((BoxCollider2D)collider).size.x;
            
            // Take the size of the collider and move it six times 
            // (Current number of obstacles).
            pos.y = Random.Range(minHeight, maxHeight);
            pos.x += widthOfObject * gameManager.obstacles.Count;

            gameManager.obstacleManager.liveObstacles[5].transform.position = pos;
            // Get a random rotation (used for the blue obstacles mainly).
            gameManager.obstacleManager.liveObstacles[5].transform.rotation = new 
                Quaternion(transform.rotation.x, startRotation[rand], 
                transform.rotation.z, transform.rotation.w);
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
