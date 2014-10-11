using UnityEngine;
using System.Collections.Generic;

public class ObstacleManager : MonoBehaviour
{
    #region Fields
    public GameManager gameManager;
    public List<GameObject> liveObstacles = new List<GameObject>();
    public Transform obstacleParent;

    private int totalLive = 6;
    private Transform selected;
    private Vector3 offset;
    private Vector3 mouseScreenPos;
    private float minHeight = -2f,
        maxHeight = 2f;
    private float spawnMinHeight = -1f,
        spawnMaxHeight = 1f;
    private float dragMinHeight = -2f,
        dragMaxHeight = 2f;
    private int startX;
    private int[] startRotation = {0,180};
    #endregion

    #region Awake
    void Awake()
    {
        //Sets the position and rotation of the obstacles that will first spawn
        if (Application.loadedLevelName == "Level1")
        {
            gameManager.obstacleCache.GetObstacle(totalLive);

            for (int i = 0; i < totalLive; i++)
            {
                int rand = Random.Range(0, 2);
                startX = 3 * i + 9;

                liveObstacles.Add(gameManager.obstacleCache.availableObstacles[i]);
                liveObstacles[i].transform.position = new Vector2(
                    startX, 
                    Random.Range(spawnMinHeight, spawnMaxHeight));
                
                liveObstacles[i].transform.rotation = new Quaternion(
                    transform.rotation.x, 
                    startRotation[rand], 
                    transform.rotation.z,
                    transform.rotation.w);
            }
        }
    }
    #endregion

    #region Update
    void Update()
    {
        //Position of the mouse on screen
        mouseScreenPos = Camera.main.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));

        // If hit has found an object and player is not dead.
        if (!gameManager.isDead)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //Gets the offset of the obstacle parent object and the position of the mouse click
                offset = obstacleParent.position - mouseScreenPos;
            }

            //If the user is holding the button down, then drag the obstacles
            if (Input.GetMouseButton(0))
                DragObstacles();
        }
    }
    #endregion

    #region DragObstacles
    void DragObstacles()
    {
        //Y value of the mouse plus offset so the distance between the object and the mouse stays the same
        float y = mouseScreenPos.y + offset.y;

        //Temp Vector3 to set the object with only the modified Y value, so that it doesnt move on the X
        Vector3 dragPos = obstacleParent.position;
        dragPos.y = y;
        dragPos.y = Mathf.Clamp(dragPos.y, dragMinHeight, dragMaxHeight);

        obstacleParent.position = dragPos;
    }
    #endregion
}
