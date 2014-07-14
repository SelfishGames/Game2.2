using UnityEngine;
using System.Collections;

public class AudioManager: MonoBehaviour
{

    #region Fields 
    public AudioClip collision;
    
    #endregion 


    void Start()
    {

    }

    public void PlaySound()
    {
        audio.PlayOneShot(collision);

    }

    void Update()
    {

    }
}
