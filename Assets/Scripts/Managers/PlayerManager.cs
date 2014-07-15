using UnityEngine;
using System.Collections;

public class PlayerManager: MonoBehaviour
{
    #region Fields
    public GameManager gameManager;
    public float speed;
    public float rotSpeed;
    public GuideController guideController;

    // Local variable.
    private GameObject playerObject;

    private float targetHeight;
    private float minHeight = -0.7f,
        maxHeight = 0.7f;
    private Vector3 targetOffset = new Vector3(8f, 0, 0);
    private Vector3 targetLocation;
    
    // Make private after testing.
    public float intensity, time;
    public bool decrease;
    #endregion

    #region Start
    void Start()
    {
        playerObject = gameObject;
    }
    #endregion

    #region Update
    void Update()
    {
        //Constantly moving the player along its local right vector
        transform.position += transform.right * speed * Time.deltaTime;

        //Everytime the player passes the target X, make a new one
        if (transform.position.x > targetLocation.x)
        {
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
        transform.GetChild(0).rotation = Quaternion.AngleAxis(45f, Vector3.forward);
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
        // Display buttons to allow restart or quit.
        gameManager.buttonManager.ActivateButtons();
        // Remove the option to pause. 
        gameManager.buttonManager.buttons[2].SetActive(false);
        // Make GameManager know the player is dead.
        gameManager.isDead = true;
        playerObject.SetActive(false);
    }
    #endregion
}


