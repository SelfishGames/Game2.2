using UnityEngine;
using System.Collections;

public class LoopMusic: MonoBehaviour
{

    #region Fields
    public AudioSource music;
    
    private GameManager gameManager;
    private static LoopMusic instance = null;
    #endregion

    
    public static LoopMusic Instance
    {
        get { return instance; }
    }

    #region Awake
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        // Music.
        music.volume = PlayerPrefs.GetFloat("Music", 1);

        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        
    }
    #endregion

    #region Update
    void Update()
    {
        if(!gameManager)
        {
            // Get gameManager in new scene. 
            GameObject gm = GameObject.Find("GameManager");
            gameManager = (GameManager)gm.GetComponent(typeof(GameManager));

        }

        if (gameManager.visibleSlider == true)
        {
            // Music.
            music.volume = gameManager.audioManager.sliderMusic.GetSliderValue();
        }
    }
    #endregion
}
