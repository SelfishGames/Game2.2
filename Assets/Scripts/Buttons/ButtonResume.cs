﻿using UnityEngine;
using System.Collections;

public class ButtonResume: MonoBehaviour
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
    }
    #endregion 

    #region OnMouseUp
    void OnMouseUp()
    {
        guiTexture.texture = defaultTexture;

        gameManager.buttonManager.Resume();
    }
    #endregion
}
