using UnityEngine;
using System.Collections.Generic;

public class TouchInput : MonoBehaviour
{
    #region Fields
    public LayerMask touchInputMask;

    private List<GameObject> touchList = new List<GameObject>();
    private GameObject[] oldTouch;
    private RaycastHit hit;
    #endregion

    #region Start
    void Start()
    {

    }
    #endregion

    #region Update
    void Update()
    {
        if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0))
        {
            oldTouch = new GameObject[touchList.Count];
            touchList.CopyTo(oldTouch);
            touchList.Clear();

            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, touchInputMask))
            {
                GameObject recipient = hit.transform.gameObject;
                touchList.Add(recipient);

                if (Input.GetMouseButtonDown(0))
                {
                    recipient.SendMessage("OnTouchDown", hit.point, SendMessageOptions.DontRequireReceiver);
                }
                if (Input.GetMouseButtonUp(0))
                {
                    recipient.SendMessage("OnTouchUp", hit.point, SendMessageOptions.DontRequireReceiver);
                }
                if (Input.GetMouseButton(0))
                {
                    recipient.SendMessage("OnTouchStay", hit.point, SendMessageOptions.DontRequireReceiver);
                }
            }

            foreach (GameObject g in oldTouch)
            {
                if (!touchList.Contains(g))
                {
                    g.SendMessage("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
                }
            }
        }
        //if (Input.touchCount > 0)
        //{

        //    oldTouch = new GameObject[touchList.Count];
        //    touchList.CopyTo(oldTouch);
        //    touchList.Clear();

        //    foreach (Touch touch in Input.touches)
        //    {
        //        Ray ray = camera.ScreenPointToRay(touch.position);


        //        if (Physics.Raycast(ray, out hit, touchInputMask))
        //        {
        //            GameObject recipient = hit.transform.gameObject;
        //            touchList.Add(recipient);

        //            if (touch.phase == TouchPhase.Began)
        //            {
        //                recipient.SendMessage("OnTouchDown", hit.point, SendMessageOptions.DontRequireReceiver);
        //            }
        //            if (touch.phase == TouchPhase.Ended)
        //            {
        //                recipient.SendMessage("OnTouchUp", hit.point, SendMessageOptions.DontRequireReceiver);
        //            }
        //            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
        //            {
        //                recipient.SendMessage("OnTouchStay", hit.point, SendMessageOptions.DontRequireReceiver);
        //            }
        //            if (touch.phase == TouchPhase.Canceled)
        //            {
        //                recipient.SendMessage("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
        //            }
        //        }
        //    }
        //    foreach(GameObject g in oldTouch)
        //    {
        //        if(!touchList.Contains(g))
        //        {
        //            g.SendMessage("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
        //        }
        //    }
        //}
    }
    #endregion
}
