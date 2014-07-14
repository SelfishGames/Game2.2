using UnityEngine;
using System.Collections;

public class BG: MonoBehaviour
{
    #region fields
    public int offset;

    public Transform player;
    #endregion 

    void Update()
    {

        if(transform.localPosition.x + offset < player.transform.localPosition.x)
        {
            transform.localPosition = new Vector3(transform.localPosition.x + 10 * 3, transform.localPosition.y);

        }
    }
}
