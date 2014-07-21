using UnityEngine;
using System.Collections;

public class ButtonBack: MonoBehaviour
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
        gameManager.buttonManager.Back();
        gameManager.audioManager.audioFiles[3].Play();
        guiTexture.texture = defaultTexture;
    }
    #endregion
}
