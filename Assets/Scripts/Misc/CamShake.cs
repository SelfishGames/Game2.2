using UnityEngine;
using System.Collections;

public class CamShake : MonoBehaviour
{
    #region Fields


    private Vector3 initialPos;
    private float shakeIntensity;
    private float shakeTime;
    private float currentIntensity;
    private float currentTime;
    private bool decrease;
    private Vector3 rand;
    #endregion

    #region Start
    void Start()
    {
        initialPos = transform.localPosition;
        rand = Vector3.one;
    }
    #endregion

    #region Update
    void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime >= 0)
        {
            rand.x = Random.value - 0.5f;
            rand.y = Random.value - 0.5f;
            rand.z = Random.value - 0.5f;
            transform.localPosition = Vector3.Lerp(transform.localPosition, initialPos + (rand * currentIntensity), 0.4f);

            if (decrease)
            {
                currentIntensity = shakeIntensity * (currentTime / shakeTime);
            }
        }
    }
    #endregion

    #region Shake
    public void Shake(float intensity, float time, bool decreaseIntensity)
    {
        initialPos = transform.localPosition;

        shakeIntensity = intensity;
        shakeTime = time;

        currentIntensity = intensity;
        currentTime = time;

        decrease = decreaseIntensity;
    }
    #endregion
}
