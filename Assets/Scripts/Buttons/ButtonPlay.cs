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
        gameManager.audioManager.audioFiles[1].Play();
    }
    #endregion

    #region OnMouseUp
    void OnMouseUp()
    {
        gameManager.audioManager.audioFiles[2].Play();
        guiTexture.texture = defaultTexture;

        StartCoroutine("CallPlay");

    }
    #endregion

    IEnumerator CallPlay()
    {
        yield return new WaitForSeconds(.2f);
        if (gameManager.playCount == 0)
        {
            gameManager.buttonManager.Play(1);
        }
        else
        {
            gameManager.buttonManager.Play(2);
        }
    }
}
