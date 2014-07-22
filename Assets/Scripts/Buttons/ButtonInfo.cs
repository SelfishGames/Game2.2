﻿using UnityEngine;
using System.Collections;

public class ButtonInfo : MonoBehaviour
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
        gameManager.audioManager.audioFiles[1].Play();
    }
    #endregion

    #region OnMouseUp
    void OnMouseUp()
    {
        gameManager.buttonManager.Info();
        gameManager.audioManager.audioFiles[2].Play();
        guiTexture.texture = defaultTexture;
        
    }
    #endregion
}
