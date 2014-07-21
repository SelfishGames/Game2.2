using UnityEngine;
using System.Collections.Generic;

public class AudioManager: MonoBehaviour
{

    #region Fields 
    public SliderSound sliderSound;
    public SliderMusic sliderMusic;
    public List<AudioSource> audioFiles = new List<AudioSource>();
    public GameManager gameManager;
    public GameObject[] sliders;  
    #endregion 

    #region Awake
    void Awake()
    {
        audioFiles[0].volume = PlayerPrefs.GetFloat("Sound", 1);
        audioFiles[1].volume = PlayerPrefs.GetFloat("Music", 1);
    }
    #endregion

    public void PlaySound()
    {
        audioFiles[0].Play();
    }

    void Update()
    {
        if(gameManager.visibleSlider == true)
        {
            audioFiles[0].volume = sliderSound.GetSliderValue();
            audioFiles[1].volume = sliderMusic.GetSliderValue();

        }
    }

    void OnDestroy()
    {
        // Store volume choices.
        //PlayerPrefs.SetFloat("Sound", audioFiles[0].volume);
        //PlayerPrefs.SetFloat("Music", audioFiles[1].volume);

        //PlayerPrefs.SetFloat("musicKnobX", sliderMusic.knob.position.x);
        //PlayerPrefs.SetFloat("soundKnobX", sliderSound.knob.position.x);
        //Debug.Log("AudioManager onDestroy");
    }
}
