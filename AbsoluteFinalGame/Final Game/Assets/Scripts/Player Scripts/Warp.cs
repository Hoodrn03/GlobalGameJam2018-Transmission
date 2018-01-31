using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour {

    //---------------------------------------------------
    //                      Header 
    //
    //  This will be used to warp the player. This will
    //  be used as a stand in replacement for a jump.
    //
    //                          Why are you running...?
    //
    //---------------------------------------------------
    //              Data Members
    //---------------------------------------------------

    // Will be used to check if the mouse is within the trigger. 
    [SerializeField]
    private bool bIsTriggered = false;

    // This will be used to refernce the mouses possition (The warp location). 
    [SerializeField]
    private GameObject warpLocation;

    // This will reference the warlock which will be warped. 
    [SerializeField]
    private GameObject warlockToWarp;

    // THis will be used to check if the player is on the floor. 
    [SerializeField]
    bool bIsOnGround = true;

    //---------------------------------------------------
    //              Member Functions 
    //---------------------------------------------------

    // Use this for initialization

    void Start ()
    {
	    	
	}
	
	// Update is called once per frame

	void Update ()
    {
        // If the mouse has been triggered and the player is on the ground. 

        if (bIsTriggered == true && bIsOnGround == true)
        {
            // The player is teleported. 
            if (warlockToWarp.GetComponent<WarlockScript>().getWarlockIsControlled() == true)
            {
                teleport();

                bIsTriggered = false;
            }   
        }
         
	}

    // This will be used to detect whether the empty game object (warp point) is within the warlock's trigger.  

    void OnTriggerStay2D(Collider2D other)
    {

        // If the teleport location is within the player's trigger, 

        if (other.tag == "Location")
        {

            // Debug.Log("hit");

            // and if the mouse button is pressed, 

            if (Input.GetMouseButtonDown(0))
            {
                bIsTriggered = true;
            }
        }
    }

    // This will be used to limit the teleport to only be useable when the player is on the floor. 

    private void OnCollisionEnter2D(Collision2D collision)
    {

        // If the player is colliding with something marked as Platforms:

        if (collision.collider.tag == "Platforms") 
        {
            bIsOnGround = true;
        }
    }

    // Thi will make the warlock move to the mouses current possition. 

    void teleport()
    {
        // The warlock is instantly moved to the possition of the Warp location 

        warlockToWarp.transform.position = warpLocation.transform.position;

        warlockToWarp.GetComponent<WarlockScript>().castWarp();

    }

}
