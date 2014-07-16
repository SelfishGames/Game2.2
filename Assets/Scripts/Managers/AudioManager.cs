using UnityEngine;
using System.Collections;

public class AudioManager: MonoBehaviour
{

    #region Fields 
    public Slider slider;
    public AudioClip collision;
    public GameObject[] sliders;
    
    #endregion 


    void Start()
    {

    }

    public void PlaySound()
    {
        audio.PlayOneShot(collision);

    }

    void Update()
    {
        audio.volume = slider.GetSliderValue();
    }
}
