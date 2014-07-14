using UnityEngine;
using System.Collections;

public class ObstacleMove: MonoBehaviour
{

    #region Fields
    public GameManager gameManager;
    public bool isHit = false; 
    private float rand;
    #endregion 

    #region Start
    void Start()
    {
        rand = Random.Range(-1f, 1f);
    }
    #endregion

    #region Update
    void Update()
    {
        if (!isHit)
        {
            transform.position = new Vector2(transform.position.x, Mathf.Sin(Time.time) * rand);
        }
    }
    #endregion
}
