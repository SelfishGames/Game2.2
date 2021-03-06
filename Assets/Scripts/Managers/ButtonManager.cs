﻿using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class ButtonManager : MonoBehaviour
{
    #region Fields
    public List<GameObject> buttons = new List<GameObject>();
    public GameManager gameManager;
    public bool pause = false;
    public bool home = false;
    public bool quit = false;

    public GameObject infoObject;

    //private LoopMusic loopMusic;
    private int click = 0;
    public bool challengeDown;
    #endregion

    #region Awake
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        challengeDown = true;
    }
    #endregion

    #region Pause
    public void Pause()
    {
        pause = true;
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
        if(Application.loadedLevelName == "Tutorial" || gameManager.playCount % 3 != 0)
        {
            Application.LoadLevel(level);
        }

        else
        {
            Application.LoadLevel(level);

            if (gameManager.activeAd == false)
            {
                //Application.LoadLevel(level);
            }           
        }
    }
    #endregion

    #region Quit
    public void Quit()
    {
        quit = true;
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
        // Hide challenge button.
        //buttons[7].SetActive(false);
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

        challengeDown = false;

        if (click == 1)
        {
            RemoveCredits();
        }
    }
    #endregion

    #region Challenge
    //public void Challenge()
    //{
    //    // Hide info button.
    //    buttons[0].SetActive(false);
    //    // Hide play button.
    //    buttons[4].SetActive(false);
    //    // Hide option button.
    //    buttons[3].SetActive(false);
    //    // Hide challenge button.
    //    //buttons[7].SetActive(false);
    //    // Show Back Button.
    //    buttons[6].SetActive(true);
    //    // Reposition quit button.
    //    buttons[2].transform.position = buttons[3].transform.position;
    //    gameManager.gameTitle.SetActive(false);

    //    //// Toggle info button.
    //    //buttons[0].SetActive(!buttons[0].activeSelf);
    //    //// Toggle play button.
    //    //buttons[4].SetActive(!buttons[4].activeSelf);
    //    //// Toggle option button.
    //    //buttons[3].SetActive(!buttons[3].activeSelf);
    //    //// Toggle quit button.
    //    //buttons[2].SetActive(!buttons[2].activeSelf);
    //    // Toggle challenge board.
    //    gameManager.challengeBoard.SetActive(!gameManager.challengeBoard.activeSelf);
    //    // Toggle the player object.
    //    gameManager.player.gameObject.SetActive(!gameManager.player.gameObject.activeSelf);
    //    // Toggle the game title. 
    //    gameManager.gameTitle.SetActive(false);
    //    //// Toggle challenge text. 
    //    //gameManager.challengeText.gameObject.SetActive(!gameManager.challengeText.gameObject.activeSelf);

    //    if (click == 1)
    //    {
    //        RemoveCredits();
    //    }
    //}
    #endregion

    #region ButtonHome
    public void ButtonHome()
    {
        home = true;

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
        // Show challenge.
        //buttons[7].SetActive(true);
        // Reset quit location.
        buttons[2].transform.position = new Vector2(0.6f, buttons[2].transform.position.y);

        // Toggle challenge board.
        gameManager.challengeBoard.SetActive(false);
        // Toggle the player object.
        gameManager.player.gameObject.SetActive(true);
        // Toggle the game title. 
        gameManager.gameTitle.SetActive(true);

        for (int i = 0; i < 2; i++)
        {
            gameManager.audioManager.sliders[i].SetActive(false);
        }
        gameManager.visibleSlider = false;

        ////Sets the playerprefs for the volume and slider knob positions
        ////when the options menu is exited
        //PlayerPrefs.SetFloat("Sound", gameManager.audioManager.audioFiles[0].volume);
        //PlayerPrefs.SetFloat("ClickDown", gameManager.audioManager.audioFiles[1].volume);
        //PlayerPrefs.SetFloat("ClickUp", gameManager.audioManager.audioFiles[2].volume);


        //if (!gameManager.loopMusic)
        //{
        //    // Get gameManager in new scene.
        //    GameObject gm = GameObject.Find("GameMusic");
        //    loopMusic = (LoopMusic)gm.GetComponent(typeof(LoopMusic));

        //    PlayerPrefs.SetFloat("Music", loopMusic.music.volume);
        //}

        //PlayerPrefs.SetFloat("musicKnobX", gameManager.audioManager.sliderMusic.knob.position.x);
        //PlayerPrefs.SetFloat("soundKnobX", gameManager.audioManager.sliderSound.knob.position.x);
    }
    #endregion

    #region Info
    public void Info()
    {
        gameManager.gameTitle.SetActive(false);

        infoObject.SetActive(true);

        //Highscore
        infoObject.transform.GetChild(0).guiText.text =
            "HighScore : " + PlayerPrefs.GetInt("highScore");
        //Total pillars
        infoObject.transform.GetChild(1).guiText.text =
            "Total # of pillars passed\nover lifetime : " + PlayerPrefs.GetInt("pillarsPassedTotal");
        //Pillars in a round
        infoObject.transform.GetChild(2).guiText.text =
            "Highest # of pillars passed\nin a round : " + PlayerPrefs.GetInt("pillarsPassedHighScore");
        //Total near misses
        infoObject.transform.GetChild(3).guiText.text =
            "Total # of near-misses\nover lifetime : " + PlayerPrefs.GetInt("nearmissTotal");
        //Near misses in a round
        infoObject.transform.GetChild(4).guiText.text =
            "Highest # of near-misses\nin a round : " + PlayerPrefs.GetInt("nearmissHighScore");
        //Number of games played
        infoObject.transform.GetChild(5).guiText.text =
            "# of games played : " + PlayerPrefs.GetInt("totalGamesPlayed");

        if (click == 0)
        {
            click++;
            gameManager.credits.SetActive(true);
        }

        else if (click == 1)
        {
            gameManager.gameTitle.SetActive(true);

            infoObject.SetActive(false);

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

        gameManager.credits.SetActive(false);
        gameManager.creditManager.ResetPosition();
    }
    #endregion
}
