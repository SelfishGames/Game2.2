using UnityEngine;
using System.Collections;

public class GUIAspectRatio : MonoBehaviour
{
    #region Fields
    // Set the desired ration in the inspector.
    public Vector2 scaleRatio;

    private Transform myTransform;
    private float widthHeight;
    #endregion

    #region Start
    void Start()
    {
        // Performance variable.
        myTransform = transform;
        SetScale();
    }
    #endregion

    #region SetScale
    void SetScale()
    {
        // Find the current aspect ratio.
        widthHeight = (float)Screen.width / Screen.height;
        // Apply the scale.
        myTransform.localScale = new Vector2(scaleRatio.x, widthHeight * scaleRatio.y);
    }
    #endregion
}
