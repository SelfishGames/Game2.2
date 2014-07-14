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
            ActivateButtons();
        }

        else
        {
            Time.timeScale = 1;
            DeactivateButtons();
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

    public void ActivateButtons()
    {
        // Get all buttons in the list - 1 to ignore the pause button.
        for (int i = 0; i < buttons.Count - 1; i++)
        {
            buttons[i].SetActive(true);
        }
    }

    public void DeactivateButtons()
    {
        // Get all buttons in the list - 1 to ignore the pause button.
        for (int i = 0; i < buttons.Count - 1; i++)
        {
            buttons[i].SetActive(false);
        }
    }
}
