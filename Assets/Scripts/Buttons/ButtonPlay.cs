using UnityEngine;
using System.Collections;

public class ButtonPlay : MonoBehaviour
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
        if(gameManager.playCount == 0)
        {
            gameManager.buttonManager.Play(1);
        }
        else
        {
            gameManager.buttonManager.Play(2);
        }
    }
    #endregion
}
