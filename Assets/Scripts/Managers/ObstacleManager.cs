using UnityEngine;
using System.Collections.Generic;

public class ObstacleManager : MonoBehaviour
{
    #region Fields
    public GameManager gameManager;
    public List<GameObject> liveObstacles = new List<GameObject>();

    private int totalLive = 6;
    private Transform selected;
    private Vector3 offset;
    private float minHeight = -1f;
    private float maxHeight = 1f;
    private int startX;
    #endregion

    #region Awake
    void Awake()
    {
        if (Application.loadedLevelName != "Tutorial")
        {
            gameManager.obstacleCache.GetObstacle(totalLive);

            for (int i = 0; i < totalLive; i++)
            {
                startX = 3 * i + 9;

                liveObstacles.Add(gameManager.obstacleCache.availableObstacles[i]);
                liveObstacles[i].transform.position = new Vector2(startX, Random.RandomRange(minHeight, maxHeight));
            }
        }
    }
    #endregion

    #region Update
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(
            Camera.main.ScreenToWorldPoint(Input.mousePosition),
            Vector2.zero, 0, 5 << LayerMask.NameToLayer("Obs"));

     
            // If hit has found an object and player is not dead.
            if (hit && !gameManager.isDead)
            {
                if (Input.GetMouseButtonDown(0))
                {

                    if (hit.collider.gameObject.tag == "Obstacle")
                    {
                        //If an object has not been selected yet
                        if (!selected)
                        {
                            selected = hit.transform;

                            //Gets the offset of the selected obstacle and the mouse on screen in world space
                            offset = selected.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
                        }
                    }
                }
                //Once the user lets go of mouseClick, reset selected to null
                else if (Input.GetMouseButtonUp(0))
                {
                    selected = null;
                }
            }
            else
            {
                //If hit is null
                return;
            }
        

        if (selected)
        {
            DragObstacle();

            ////Gets all obstacles with the same tag as the one that has been selected
            ////and also only if they are visible on the screen
            //var selectedArray = from obs in gameManager.obstacles
            //                    where (obs.tag == selected.tag) && obs.renderer.isVisible == true
            //                    select obs.transform;

            //foreach(Transform trans in selectedArray)
            //{
            //    //Temp Vector3 to set the object with only the modified Y value, so that it doesnt move on the X
            //    Vector3 dragPos = trans.position;
            //    dragPos.y = y;
            //    dragPos.y = Mathf.Clamp(dragPos.y, minHeight, maxHeight);

            //    trans.position = dragPos;
            //}  
        }
    }
    #endregion

    #region DragObstacle
    void DragObstacle()
    {
        //Position of the mouse on screen
        Vector3 mouseScreenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);

        //Y value of the mouse plus offset so the distance between the object and the mouse stays the same
        float y = Camera.main.ScreenToWorldPoint(mouseScreenPos).y + offset.y;

        //Temp Vector3 to set the object with only the modified Y value, so that it doesnt move on the X
        Vector3 dragPos = selected.position;
        dragPos.y = y;
        dragPos.y = Mathf.Clamp(dragPos.y, minHeight, maxHeight);

        selected.position = dragPos;
    }
    #endregion

    #region RandomObstacle
    public void RandomObstacle(float xPos)
    {

    }
    #endregion
}
