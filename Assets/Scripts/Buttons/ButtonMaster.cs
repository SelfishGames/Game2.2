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
        // Check which button has been pressed and call
        // the related function.
        string name = gameObject.name;
        switch (name)
        {
            case "Back":
                gameManager.buttonManager.Back();
                break;
            case "Home":
                gameManager.buttonManager.ButtonHome();
                break;
            case "Info":
                gameManager.buttonManager.Info();
                break;
            case "Quit":
                gameManager.buttonManager.Quit();
                break;
            case "Options":
                gameManager.buttonManager.Options();
                break;
            case "Play":
                StartCoroutine("CallPlay");
                break;
            case "Pause":
                gameManager.buttonManager.Pause();
                break;
            case "Challenge":
                gameManager.buttonManager.Challenge();
                break;
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
