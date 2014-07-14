using UnityEngine;
using System.Collections.Generic;

public class ObstacleLooper : MonoBehaviour
{
    #region Fields

    public GameManager gameManager;

    private float minHeight = -1f;
    private float maxHeight = 1f;

    #endregion


    #region Start
    void Start()
    {

        foreach (Transform obs in gameManager.obstacles)
        {
            Vector2 pos = obs.transform.position;
            pos.y = Random.Range(minHeight, maxHeight);
            obs.transform.position = pos;

        }
    }
    #endregion 


    #region OnTriggerEnter
    void OnTriggerEnter2D(Collider2D collider)
    {
        Vector2 pos = collider.transform.position;

        // Logic to move the pipes based on their collider size.
        if (collider.tag == "ObsGrey" || collider.tag == "ObsOrange")
        {
            float widthOfObject = ((BoxCollider2D)collider).size.x;

            // Take the size of the collider and move it six times 
            // (Current number of obstacles).
            pos.y = Random.Range(minHeight, maxHeight);
            pos.x += widthOfObject * gameManager.obstacles.Count;

            collider.transform.position = pos;
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
