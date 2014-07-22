using UnityEngine;
using System.Collections;

public class BG: MonoBehaviour
{
    #region fields
    public int offset;

    public Transform player;
    #endregion 

    #region Update
    void Update()
    {
        //Keeps the background pieces moving with the player
        if(transform.localPosition.x + offset < player.transform.localPosition.x)
        {
            transform.localPosition = new Vector3(transform.localPosition.x + 10 * 3, transform.localPosition.y);
        }
    }
    #endregion
}
