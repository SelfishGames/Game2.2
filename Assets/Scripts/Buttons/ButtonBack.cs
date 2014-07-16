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

    }
    #endregion

    #region OnMouseUp
    void OnMouseUp()
    {
        gameManager.buttonManager.Back();
        guiTexture.texture = defaultTexture;
    }
    #endregion
}
