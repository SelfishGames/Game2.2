﻿using UnityEngine;
using System.Collections;

public class ButtonPause : MonoBehaviour
{
    #region Fields
    public GameManager gameManager;
    public Texture pressedTexture;
    public Texture defaultTexture;
    #endregion

    #region OnMouseDown
    void OnMouseDown()
    {
        guiTexture.texture = pressedTexture;
        gameManager.audioManager.audioFiles[2].Play();
    }
    #endregion

    #region OnMouseUp
    void OnMouseUp()
    {
        gameManager.buttonManager.Pause();
        gameManager.audioManager.audioFiles[3].Play();
        guiTexture.texture = defaultTexture;
    }
    #endregion
}
