using UnityEngine;
using System.Collections.Generic;


public class ButtonManager : MonoBehaviour
{
    #region Fields
    public List<GameObject> buttons = new List<GameObject>();
    public GameManager gameManager;

    #endregion


    public void Pause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            buttons[1].SetActive(true);
        }

        else
        {
            Time.timeScale = 1;
            buttons[1].SetActive(false);
        }
    }

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

    public void Play(int level)
    {
        Application.LoadLevel(level);
    }

    public void Quit()
    {
        Application.Quit();
    }

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
        for(int i = 0; i < 2; i++)
        {
            gameManager.audioManager.sliders[i].SetActive(true);
        }

        gameManager.visibleSlider = true;
    }

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
    }

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
}
