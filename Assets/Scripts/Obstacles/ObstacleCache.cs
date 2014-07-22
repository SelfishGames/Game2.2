using UnityEngine;
using System.Collections.Generic;

public class ObstacleCache : MonoBehaviour
{
    #region Fields
    public GameManager gameManager;
    public List<GameObject> availableObstacles = new List<GameObject>();

    private int listLocation;
    #endregion

    #region ShuffleList
    private void ShuffleList()
    {
        // Always shuffles on new load to randomise the order they are picked. 
        // Goes through each obstacle in the cache and swaps its location in the list with
        // another obstacle.
        for (int i = 0; i < availableObstacles.Count; i++)
        {
            GameObject temp = availableObstacles[i];
            int randomLocal = Random.Range(0, availableObstacles.Count);
            availableObstacles[i] = availableObstacles[randomLocal];
            availableObstacles[randomLocal] = temp;
        }
    }
    #endregion

    #region GetObstacle
    // GetObstacle is to control the first bunch of obstacles, only called once. 
    public GameObject GetObstacle(int liveOBstacles)
    {
        ShuffleList();

        //Finds the first inactive obstacle and sets it to active
        int x = 0;
        // Find the amount of liveObstacles (obstacles needed to fill the screen), 
        // set them to active and pass them back to obstacle manager for use to 
        // position on screen.
        for (; x < liveOBstacles; x++)
        {
            if (availableObstacles[x].gameObject.activeSelf == false)
            {
                availableObstacles[x].gameObject.SetActive(true);
            }
        }
        return availableObstacles[x];
    }
    #endregion

    #region ChangeObstacle
    // ChangeObstacle is used to change the obstacle that has gone off screen.
    public GameObject ChangeObstacle()
    {
        // Choose a random element in the list of ALL available obstacles. 
        int element = Random.Range(0, availableObstacles.Count);

        // If it is false then set it active for use. 
        if (availableObstacles[element].gameObject.activeSelf == false)
        {
            availableObstacles[element].gameObject.SetActive(true);
            listLocation = element;
        }
        // If the random obstacle was not inactive, the obstacle is currently on screen
        // So re call this function to find an available obstacle. 
        else
        {
            ChangeObstacle();
        }

        return availableObstacles[listLocation];
    }
    #endregion
}
