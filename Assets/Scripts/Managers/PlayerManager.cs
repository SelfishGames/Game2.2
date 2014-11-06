using UnityEngine;
using System.Collections;

public class PlayerManager: MonoBehaviour
{
    #region Fields
    public GameManager gameManager;
    public float speed = 3f;

    // Local variable.
    private GameObject playerObject;

    private float minHeight = -0.6f,
        maxHeight = 0.6f;
    private float targetHeight;
    private Vector3 targetOffset = new Vector3(7f, 0, 0);
    private Vector3 targetLocation;
 
    //rotSpeed is how fast it rotates
    private float rotSpeed = 0.8f;

    private bool recentNearMiss;
    private GameObject newObstacle,
        oldObstacle;
    
    // Make private after testing.
    public float intensity, time;
    public bool decrease;
    #endregion

    #region Start
    void Start()
    {
        playerObject = gameObject;
        recentNearMiss = false;
    }
    #endregion

    #region Update
    void Update()
    {
        //Constantly moving the player along its local right vector
        transform.position += transform.right * speed * Time.deltaTime;

        if(Application.loadedLevelName != "Tutorial")
        {
            //Everytime the player passes the target X, make a new one
            if (transform.position.x > targetLocation.x)
            {
                //Picks a random height, offsets the target from the players
                //current position and then assigns the Y-value
                targetHeight = Random.Range(minHeight, maxHeight);
                targetLocation = transform.position + targetOffset;
                targetLocation.y = targetHeight;
            }

            //Direction to the new target, gets the angle as a float, then converts
            //that into a quaternion to assign to the player transform
            Vector3 direction = targetLocation - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion targetRot = Quaternion.AngleAxis(angle, Vector3.forward);

            //Slerps to face the targetLocation
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime * rotSpeed);

            //Locks the children (collider/sprite) to 45degrees rotation
            //transform.GetChild(0).rotation = Quaternion.AngleAxis(45f, Vector3.forward);

            transform.GetChild(1).particleSystem.startRotation = this.transform.rotation.z * Mathf.Deg2Rad;
            transform.GetChild(2).particleSystem.startRotation = this.transform.rotation.z * Mathf.Deg2Rad;
        }
    }
    #endregion

    #region CollisionEnter
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Play sound.
        gameManager.audioManager.PlaySound();
        // Call for camera shake.
        gameManager.camShake.Shake(intensity, time, decrease);

#if UNITY_ANDROID
        // Make device vibrate.
        Handheld.Vibrate();
#endif
        // Display explosion.
        gameManager.TriggerCollision();
        // Activate invisible anywhere button.
        gameManager.buttonManager.buttons[7].SetActive(true);
        // Make GameManager know the player is dead.
        gameManager.isDead = true;
        gameManager.collided = true;
        gameManager.touchCount = 0;
        gameManager.activeAd = true;
        gameManager.playCount++; 

        if (Application.loadedLevelName == "Level1")
        {
            gameManager.pointsManager.playerScoreEnd.gameObject.SetActive(true);
            gameManager.pointsManager.highScoreEnd.gameObject.SetActive(true);
            gameManager.pointsManager.highScoreDisplay.SetActive(true);
            // Remove the option to pause. 
            gameManager.buttonManager.buttons[5].SetActive(false);
            // Show home button.
            gameManager.buttonManager.buttons[1].SetActive(true);
            // Show quit button.
            gameManager.buttonManager.buttons[2].SetActive(true);
        }
        playerObject.SetActive(false);
    }
    #endregion

    #region TriggerEnter
    void OnTriggerEnter2D(Collider2D col)
    {
        //Resets the near miss bool after passing an obstacle
        if(col.gameObject.layer == LayerMask.NameToLayer("Obs"))
        {
            recentNearMiss = false;
        }
    }
    #endregion

    #region TriggerExit
    void OnTriggerExit2D(Collider2D col)
    {
        //Checks if the trigger hits an actual pipe
        if (col.gameObject.name == "ObsGreen" || col.gameObject.name == "ObsOrange" || col.gameObject.name == "ObsBlue")
        {
            //If the player has not "Nearly missed" this obstacle yet
            if (!recentNearMiss)
            {
                recentNearMiss = true;

                //Applies the bonus points after passing the obstacle
                gameManager.pointsManager.NearMissBonus();
            }
        }
    }
    #endregion
}


