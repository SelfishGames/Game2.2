using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class ButtonManager : MonoBehaviour
{
    #region Fields
    public List<GameObject> buttons = new List<GameObject>();
    public GameManager gameManager;

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
            buttons[5].SetActive(true);
        }

        else
        {
            gameManager.isDead = false;
            Time.timeScale = 1;
            buttons[1].SetActive(false);
            buttons[5].SetActive(false);
        }
    }
    #endregion

    #region Resume
    public void Resume()
    {
        if (gameManager.isDead == true)
        {
            Application.LoadLevel(Application.loadedLevel);
        }

        else
        {
            Time.timeScale = 1;
            DeactivateButtons();
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
        buttons[0].SetActive(false);
        buttons[2].SetActive(false);
        if (Application.loadedLevelName == "MainMenu")
        {
            buttons[3].SetActive(true);
        }

        buttons[1].transform.position = buttons[2].transform.position;
        if (Application.loadedLevelName == "MainMenu")
        {
            gameManager.gameTitle.SetActive(false);
        }
        for (int i = 0; i < 2; i++)
        {
            gameManager.audioManager.sliders[i].SetActive(true);
        }

        gameManager.visibleSlider = true;
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
        buttons[3].SetActive(false);
        buttons[2].SetActive(true);
        buttons[0].SetActive(true);

        buttons[1].transform.position = new Vector2(0.6f, buttons[1].transform.position.y);
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

    #region ActivateButtons
    public void ActivateButtons()
    {
        buttons[0].SetActive(true);
        buttons[1].SetActive(true);
    }

    public void DeactivateButtons()
    {
        buttons[0].SetActive(false);
        buttons[1].SetActive(false);
    }
    #endregion

    #region GoToMenu
    IEnumerator GoToMenu()
    {
        yield return new WaitForSeconds(0.1f);

        Application.LoadLevel(0);
    }

    #endregion
}
