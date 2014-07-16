using UnityEngine;
using System.Collections;

public class Button: MonoBehaviour
{

    #region Fields
    public Color def;
    public Color selected;

    private Material mat;
    #endregion 

    #region Start
    void Start()
    {
        mat = renderer.material;
    }
    #endregion


    #region Update
    void Update()
    {

    }
    #endregion

    void OnTouchDown()
    {
        mat.color = selected;

    }
    void OnTouchUp()
    {
        mat.color = def;

    }
    void OnTouchStay()
    {
        mat.color = selected;

    }
    void OnTouchExit()
    {

        mat.color = def;
    }
}
