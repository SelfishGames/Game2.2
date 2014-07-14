using UnityEngine;
using System.Collections;

public class PlayerManager: MonoBehaviour
{
    #region Fields
    public GameManager gameManager;
    public float speed;
    public GuideController guideController;
    public float frequency;

    // Local variable.
    private GameObject playerObject;
    private float offset;
    private Vector3 currentVelocity;
    private float randSeed;
    private Transform selected;
    private Vector3 targetLocation;
    

    // Make private after testing.
    public float intensity, time;
    public bool decrease;
    #endregion

    void Start()
    {
        // Basic randomisation at beginning of each new game. (will need to be improved to randomise
        // mid game).
        randSeed = Random.Range(200f, 400f);
        offset = Random.Range(-1f, 1f);
        while (offset == 0)
        {
            offset = Random.Range(-1f, 1f);
        }
        playerObject = gameObject;
    }

    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;

        if (guideController.trailLocations.Count == 0)
            return;

        ///////////////// ------------ Andy Approach --------------- \\\\\\\\\\\\\\\\\\\\
        //Sets the target location to the first one in the list
        targetLocation = guideController.trailLocations[0];

        //Direction to the new target, gets the angle as a float, then converts
        //that into a quaternion to assign to the player transform
        Vector3 direction = targetLocation - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRot = Quaternion.AngleAxis(angle, Vector3.forward);

        //Slerps to face the targetLocation
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime);

        //If the player square has not passed the current targets X position
        if (transform.position.x > targetLocation.x)
        {
            //Removes the location when the player moves passed it
            guideController.trailLocations.RemoveAt(0);
        }

        //Locks the children (collider/sprite) to 45degrees rotation
        transform.GetChild(0).rotation = Quaternion.AngleAxis(45f, Vector3.forward);
    }

    #region FixedUpdate
    void FixedUpdate()
    {
        // Moves player forward. 
        //transform.position += transform.right * speed * Time.deltaTime;


        ///////////////// ------------ Rob Approach --------------- \\\\\\\\\\\\\\\\\\\\
        // Control up and down movement.
        // Better movement but fucks up when object is rotated due to basing off of rigidbody.
        //currentVelocity = rigidbody2D.velocity;
        //currentVelocity.y = Mathf.Sin((Time.time + randSeed) * frequency) * offset;
        //rigidbody2D.velocity = currentVelocity;
        // Not screwed up but not as random.
        //Vector3 pos = transform.localPosition;
        //pos.y = Mathf.Sin((Time.time + randSeed) * frequency) * offset;
        //transform.localPosition = pos;


        ///////////////// ------------ Andy Approach --------------- \\\\\\\\\\\\\\\\\\\\
        ////Sets the target location to the first one in the list
        //targetLocation = guideController.trailLocations[0];

        ////Direction to the new target, gets the angle as a float, then converts
        ////that into a quaternion to assign to the player transform
        //Vector3 direction = targetLocation - transform.position;
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //Quaternion targetRot = Quaternion.AngleAxis(angle, Vector3.forward);

        ////Slerps to face the targetLocation
        //transform.rotation = Quaternion.identity;

        ////If the player square has not passed the current targets X position
        //if (transform.position.x > targetLocation.x)
        //{
        //    //Removes the location when the player moves passed it
        //    guideController.trailLocations.RemoveAt(0);
        //}
    }
    #endregion

    #region CollisionEnter
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Play sound.
        gameManager.audioManager.PlaySound();
        // Call for camera shake.
        gameManager.camShake.Shake(intensity, time, decrease);
        // Make device vibrate.
        Handheld.Vibrate();
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


