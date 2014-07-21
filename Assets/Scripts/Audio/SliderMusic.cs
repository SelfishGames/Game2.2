﻿using UnityEngine;
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
    private float displayValue;
    #endregion

    void Awake()
    {
        targetPos = knob.position;
        targetPos.x = PlayerPrefs.GetFloat("musicKnobX");
        knob.position = targetPos;
    }

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
        displayValue = Mathf.Lerp(valueRange[0], valueRange[1], sliderPercent);

        textMesh.text = sliderName + ": " + displayValue.ToString("F" + decimalPlaces);
    }
    #endregion

    void OnTouchStay(Vector3 point)
    {
        targetPos = new Vector3(point.x, targetPos.y, targetPos.z);
    }

    public float GetSliderValue()
    {
        return sliderPercent;
    }
}
