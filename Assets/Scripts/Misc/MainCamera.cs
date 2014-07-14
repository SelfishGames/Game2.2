using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour
{
    #region Fields
    public Transform player;

    private float offsetX;
    #endregion

    #region Start
    void Start()
    {
        offsetX = transform.position.x - player.position.x;
    }
    #endregion

    #region Update
    void Update()
    {
        if (player != null)
        {
            Vector3 pos = transform.position;
            pos.x = player.position.x + offsetX;
            transform.position = pos;
        }
    }
    #endregion
}
