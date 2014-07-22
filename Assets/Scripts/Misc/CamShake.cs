using UnityEngine;
using System.Collections;

public class CamShake : MonoBehaviour
{
    #region Fields
    // Allow intensity to be decreased before the end of the explosion.
    public bool decrease;

    // Start pos of camera.
    private Vector3 initialPos;
    // Intensity of shake.
    private float shakeIntensity;
    // Duration of shake.
    private float shakeTime;
    // Intensity at its current value.
    private float currentIntensity;
    // Current time.
    private float currentTime;
    // Store random value.
    private Vector3 rand;
    #endregion

    #region Start
    void Start()
    {
        // Start pos of the camera.
        initialPos = transform.localPosition;
        // Random value between 0-1 in all three vector points. 
        rand = Vector3.one;
    }
    #endregion

    #region Update
    void Update()
    {
        // Reduce time for duration of camera shake if selected. 
        currentTime -= Time.deltaTime;

        // Shake the camera if the timer is still lowering.
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
