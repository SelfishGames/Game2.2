using UnityEngine;
using System.Collections;

public class ButtonMaster : MonoBehaviour
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
        if(gameObject.name == "Back")
        {
            gameManager.buttonManager.Back();
        }
        if (gameObject.name == "Home")
        {
            gameManager.buttonManager.ButtonHome();
        }
        if (gameObject.name == "Info")
        {
            gameManager.buttonManager.Info();
        }
        if (gameObject.name == "Quit")
        {
            gameManager.buttonManager.Quit();
        }
        if (gameObject.name == "Options")
        {
            gameManager.buttonManager.Options();
        }
        if (gameObject.name == "Play")
        {
            StartCoroutine("CallPlay");
        }
        if (gameObject.name == "Options")
        {
            gameManager.buttonManager.Options();
        }
        if (gameObject.name == "Pause")
        {
            gameManager.buttonManager.Pause();
        }
        if (gameObject.name == "Challenge")
        {
            gameManager.buttonManager.Challenge();
        }
       
        gameManager.audioManager.audioFiles[2].Play();
        guiTexture.texture = defaultTexture;
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
