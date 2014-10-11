using UnityEngine;
using System.Collections;

public class SliderMusic: MonoBehaviour
{

    #region Fields
    public Transform knob;
    public TextMesh textMesh;
    public int[] valueRange;
    public int decimalPlaces;
    public string sliderName;

    private float sliderPercent;
    private float sliderLength;
    private Vector3 targetPos;

    #endregion

    #region Awake
    void Awake()
    {
        //Sets the knobs X pos to the last saved position
        targetPos = knob.position;
        targetPos.x = PlayerPrefs.GetFloat("musicKnobX", 4.864337f);
        knob.position = targetPos;
    }
    #endregion

    #region Start
    void Start()
    {
        targetPos = knob.position;
        sliderLength = GetComponent<BoxCollider>().size.x - .4f;
    }
    #endregion

    #region Update
    void Update()
    {
        knob.position = Vector3.Lerp(knob.position, targetPos, Time.deltaTime * 7);

        sliderPercent = Mathf.Clamp01((knob.localPosition.x + sliderLength / 2) / sliderLength);


        // This just displays the word music.
        textMesh.text = sliderName;
        // The original way we had it changing the numbers based on the sound level
        // Seemed unneeded and caused a little visual glitch the first time the slider is used. 
        //textMesh.text = sliderName + ": " + displayValue.ToString("F" + decimalPlaces);
    }
    #endregion

    #region OnTouchStay
    void OnTouchStay(Vector3 point)
    {
        //While the knob is being touched, drag it along the slider
        targetPos = new Vector3(point.x, targetPos.y, targetPos.z);
    }
    #endregion

    #region GetSliderValue
    public float GetSliderValue()
    {
        return sliderPercent;
    }
    #endregion
}
