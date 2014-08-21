using UnityEngine;
using System.Collections;

public class CreditRole : MonoBehaviour
{
	// Speed the credits will move.
	public float speed;	
	// Start position of the credits.
	private Vector2 startPos;

    // Use this for initialization
    void Start ()
    {
    	// Set the start point of the credits.
    	startPos = new Vector2(0.6f, -0.12f);
    	transform.position = startPos;
    }

    // Update is called once per frame
    void Update ()
    {
    	// Move the credits across the screen. 
    	transform.position += transform.right * -speed * Time.deltaTime;
    	// If it reached the edge of the screen return the credits to the start point
    	// to allow them to scroll back across.
    	if(transform.position.x < -0.9f)
    	{
    		transform.position = startPos;

    	}
    }
}
