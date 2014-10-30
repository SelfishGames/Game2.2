using UnityEngine;
using System.Collections;
using ChartboostSDK;

public class ChartboostPersistentObject : MonoBehaviour
{

    private GameManager gm;
   
    void Awake()
    {
        // Fill gameManager.
        GameObject tempGm = GameObject.Find("GameManager");
        gm = (GameManager)tempGm.GetComponent(typeof(GameManager));
    }

    void Start()
    {
        // fill the cache.
        Chartboost.cacheInterstitial(CBLocation.Default);
    }

    void Update()
    {
        // If player is dead & they have player the tutorial & they have not yet
        // touched the screen (This was to stop multiple ads), then show ad.
        if(gm.collided && Application.loadedLevelName != "Tutorial" && gm.touchCount == 0)
        {
            Debug.Log("shown");
            Chartboost.didDismissInterstitial += didDismissInterstitial;
            Chartboost.showInterstitial(CBLocation.Default);
            // Now increase touchCount to stop any further ads showing.
            gm.touchCount++;
        }        
    }

    // My understanding was that this would return that the interstitial has been dismissed.
    void OnMouseUp()
    {
        
    }

    // Which would then relay to this function that it has been closed
    // thus allowing me to control the bool value for the closed check. 
    void didDismissInterstitial(CBLocation location)
    {
        Chartboost.didDismissInterstitial -= didDismissInterstitial;
        gm.activeAd = false;
    }

    void OnDisable()
    {
        Destroy(gameObject);
    }
}
