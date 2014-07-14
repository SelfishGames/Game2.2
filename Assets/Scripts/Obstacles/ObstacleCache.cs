using UnityEngine;
using System.Collections.Generic;

public class ObstacleCache : MonoBehaviour
{

    #region Fields

    public GameManager gameManager;
    public List<GameObject> availableObstacles = new List<GameObject>();

    private int listLocation;
    #endregion 


    public GameObject GetObstacle(int liveOBstacles)
    {
       
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

    #region Start
    void Start()
    {

    }
    #endregion

    #region Update
    void Update()
    {

    }
    #endregion
}
