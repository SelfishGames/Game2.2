using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GuideController : MonoBehaviour
{
    #region Fields
    public List<Vector3> trailLocations = new List<Vector3>();
    public float xSpeed, ySpeed; 
    public float recordDelay;

    private float timer = 0;
    private float targetHeight;
    private const int CHOOSE_HEIGHT = 0,
        MOVE_TO_HEIGHT = 1;
    private int guideState;
    #endregion

    #region Start
    void Start()
    {
        guideState = CHOOSE_HEIGHT;
    }
    #endregion

    #region Update
    void Update()
    {
        //Moves player square 
        transform.position += Vector3.right * xSpeed * Time.deltaTime;

        //Constantly recording locations for the height of the trail
        timer += Time.deltaTime;
        if (timer > recordDelay)
        {
            trailLocations.Add(this.transform.position);
            timer = 0;
        }

        switch (guideState)
        {
            case CHOOSE_HEIGHT:
                ChooseHeight();
                return;
            case MOVE_TO_HEIGHT:
                MoveToHeight();
                return;
        }
    }
    #endregion

    #region ChooseHeight
    void ChooseHeight()
    {
        targetHeight = Random.Range(-1.6f, 1.6f);
        guideState = 1;
    }
    #endregion

    #region MoveToHeight
    void MoveToHeight()
    {
        //If the distance between points is more than .5f then keep closing the gap
        if (Mathf.Abs(transform.position.y - targetHeight) > 0.5f)
        {
            Vector3 tempPos = transform.position;
            tempPos.y = Mathf.Lerp(tempPos.y, targetHeight, ySpeed * Time.deltaTime);
            this.transform.position = tempPos;
        }
        else
        {
            guideState = 0;
        }
    }
    #endregion
}
