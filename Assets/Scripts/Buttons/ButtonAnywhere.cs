using UnityEngine;
using System.Collections;

public class ButtonAnywhere : MonoBehaviour
{
    #region Fields
    public GameManager gameManager;
    #endregion

    void Update()
    {
       
    }

    #region OnMouseDown
    void OnMouseDown()
    {
       if (gameManager.isDead)
        {
            StartCoroutine("CallPlay");
        }
    }
    #endregion

    #region OnMouseUp
    void OnMouseUp()
    {

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
