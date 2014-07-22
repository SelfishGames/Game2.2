using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
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
        // Sound.
        audioFiles[0].volume = PlayerPrefs.GetFloat("Sound", 1);
        audioFiles[1].volume = PlayerPrefs.GetFloat("ClickDown", 1);
        audioFiles[2].volume = PlayerPrefs.GetFloat("ClickUp", 1);
       
    }
    #endregion

    public void PlaySound()
    {
        // Play explosion when called by player.
        audioFiles[0].Play();
    }

    void Update()
    {
        if (gameManager.visibleSlider == true)
        {
            // Sound.
            audioFiles[0].volume = sliderSound.GetSliderValue();
            audioFiles[1].volume = sliderSound.GetSliderValue();
            audioFiles[2].volume = sliderSound.GetSliderValue();
        }
    }
}
