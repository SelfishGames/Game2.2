using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class ButtonManager : MonoBehaviour
{
    #region Fields
    public List<GameObject> buttons = new List<GameObject>();
    public GameManager gameManager;

    private int click = 0;
    #endregion

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    #region Pause
    public void Pause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            gameManager.isDead = true;
            buttons[1].SetActive(true);
            buttons[2].SetActive(true);
        }

        else
        {
            gameManager.isDead = false;
            Time.timeScale = 1;
            buttons[1].SetActive(false);
            buttons[2].SetActive(false);
        }
    }
    #endregion

    #region Play
    public void Play(int level)
    {
        Application.LoadLevel(level);
    }
    #endregion

    #region Quit
    public void Quit()
    {
        Application.Quit();
    }
    #endregion

    #region Options
    public void Options()
    {
        // Hide info button.
        buttons[0].SetActive(false);
        // Hide play button.
        buttons[4].SetActive(false);
        // Hide option button.
        buttons[3].SetActive(false);
        // Show Back Button.
        buttons[6].SetActive(true);
        // Reposition quit button.
        buttons[2].transform.position = buttons[3].transform.position;
       
       
        gameManager.gameTitle.SetActive(false);
        
        for (int i = 0; i < 2; i++)
        {
            gameManager.audioManager.sliders[i].SetActive(true);
        }

        gameManager.visibleSlider = true;
        
        if (click == 1)
        {
            RemoveCredits();
        }     
    }
    #endregion

    #region ButtonHome
    public void ButtonHome()
    {
        StartCoroutine("GoToMenu");
        Time.timeScale = 1;
    }
    #endregion

    #region Back
    public void Back()
    {
        // Hide back.
        buttons[6].SetActive(false);
        // Show info.
        buttons[0].SetActive(true);
        // Show play.
        buttons[4].SetActive(true);
        // Show settings.
        buttons[3].SetActive(true);
        // Reset quit location.
        buttons[2].transform.position = new Vector2(0.6f, buttons[2].transform.position.y);
        gameManager.gameTitle.SetActive(true);

        for (int i = 0; i < 2; i++)
        {
            gameManager.audioManager.sliders[i].SetActive(false);
        }
        gameManager.visibleSlider = false;

        //Sets the playerprefs for the volume and slider knob positions 
        //when the options menu is exited
        PlayerPrefs.SetFloat("Sound", gameManager.audioManager.audioFiles[0].volume);
        PlayerPrefs.SetFloat("ClickDown", gameManager.audioManager.audioFiles[2].volume);
        PlayerPrefs.SetFloat("ClickUp", gameManager.audioManager.audioFiles[3].volume);
        PlayerPrefs.SetFloat("Music", gameManager.audioManager.audioFiles[1].volume);

        PlayerPrefs.SetFloat("musicKnobX", gameManager.audioManager.sliderMusic.knob.position.x);
        PlayerPrefs.SetFloat("soundKnobX", gameManager.audioManager.sliderSound.knob.position.x);
    }
    #endregion

    #region Info
    public void Info()
    {

        if (click == 0)
        {
            click++;
            for (int i = 0; i < 4; i++)
            {
                gameManager.credits[i].SetActive(true);
            }
        }

        else if(click == 1)
        {
            RemoveCredits();
        }     
    }
    #endregion 

    #region GoToMenu
    IEnumerator GoToMenu()
    {
        yield return new WaitForSeconds(0.1f);

        Application.LoadLevel(0);
    }

    #endregion

    #region RemoveCredits
    void RemoveCredits()
    {
        click--;
        for (int i = 0; i < 4; i++)
        {
            gameManager.credits[i].SetActive(false);
        }
    }
    #endregion 
}
