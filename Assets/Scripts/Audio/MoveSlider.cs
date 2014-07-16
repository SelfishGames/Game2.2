using UnityEngine;
using System.Collections;

public class MoveSlider: MonoBehaviour
{

    #region Fields
    public GUITexture sliderBar = null;
    public GUITexture sliderWidget = null;
    public float minValue = 0;
    public float maxValue = 100;
    public float currentValue = 0;

    private bool connectedToMouse = false;
    private float originalX = 0;
    private float originalMouseX = 0;
    private float currentX = 0;
    private float halfWidgetWidth = 0; 
    #endregion 

    #region Start
    void Start()
    {
        halfWidgetWidth = (sliderWidget.pixelInset.xMax - sliderWidget.pixelInset.xMin) / 2;
        currentX = sliderWidget.pixelInset.xMin + halfWidgetWidth;
    }
    #endregion

    #region Update
    void Update()
    {
        if (connectedToMouse == true)
        {
            // calculate currentX based on mouse position
            currentX = originalX - (originalMouseX - Input.mousePosition.x);
            // translate from the pixel values to the value
            currentValue = (((currentX - sliderBar.pixelInset.xMin) / (sliderBar.pixelInset.xMax - sliderBar.pixelInset.xMin)) * (maxValue - minValue)) + minValue;
        }
        // make sure the value isn't out of bounds
        if (currentValue < minValue)
        {
            currentValue = minValue;
        }
        else if (currentValue > maxValue)
        {
            currentValue = maxValue;
        }
        // update where the sliderWidget is drawn from currentValue (in case the value is changed externally)
        currentX = (((currentValue - minValue) / (maxValue - minValue)) * (sliderBar.pixelInset.xMax - sliderBar.pixelInset.xMin)) + sliderBar.pixelInset.xMin;
        sliderWidget.pixelInset = new Rect((currentX - halfWidgetWidth), sliderWidget.pixelInset.yMin, (currentX + halfWidgetWidth) - (currentX - halfWidgetWidth), sliderWidget.pixelInset.yMax - sliderWidget.pixelInset.yMin);

        // now do something with that new value!
        AudioListener.volume = currentValue;
    }
    #endregion

    void OnMouseDown()
    {
        connectedToMouse = true;
        originalMouseX = Input.mousePosition.x;
        originalX = sliderWidget.pixelInset.xMin + halfWidgetWidth;
    }

    void OnMouseUp()
    {
        connectedToMouse = false;
    }
}
