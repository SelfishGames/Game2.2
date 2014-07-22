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
        //Shuffles the list of obstacles to make it rando everytime
        for(int i = 0; i < availableObstacles.Count; i++)
        {
            GameObject temp = availableObstacles[i];
            int randomLocal = Random.Range(0, availableObstacles.Count);
            availableObstacles[i] = availableObstacles[randomLocal];
            availableObstacles[randomLocal] = temp;
        }
    }
    #endregion

    #region GetObstacle
    public GameObject GetObstacle(int liveOBstacles)
    {
        //Shuffles the list to get a totally random obstacle
        ShuffleList();

        //Finds the first inactive obstacle and sets it to active
        int x = 0;
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
    public GameObject ChangeObstacle()
    {
        int element = Random.Range(0, availableObstacles.Count);

        if (availableObstacles[element].gameObject.activeSelf == false)
        {
            availableObstacles[element].gameObject.SetActive(true);
            listLocation = element;
        }
        else
        {
            ChangeObstacle();
        }

        return availableObstacles[listLocation];
    }
    #endregion
}
