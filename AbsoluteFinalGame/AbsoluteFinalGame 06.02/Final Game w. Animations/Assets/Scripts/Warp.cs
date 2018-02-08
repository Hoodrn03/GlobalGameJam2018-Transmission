using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour {

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

	// Use this for initialization
	void Start ()
    {
	    	
	}
	
	// Update is called once per frame
	void Update () {

        if (bIsTriggered == true && bIsOnGround == true && warlockToWarp.GetComponent<ControlSwitch>().getIsControlled() == true)
        {
            teleport();

            bIsTriggered = false;   
        }
         
	}

    // This will be used to detect whether the empty game object (warp point) is within the warlock's trigger.  

    void OnTriggerStay2D(Collider2D other)
    {

        if (other.tag == "Location")
        {

            // Debug.Log("hit");

            if (Input.GetMouseButtonDown(0))
            {
                bIsTriggered = true;
            }
        }
    }

    // This will be used to limit the teleport to only be useable when the player is on the floor. 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Platforms") 
        {
            bIsOnGround = true;
        }
    }

    // Thi will make the warlock move to the mouses current possition. 

    void teleport()
    {

        warlockToWarp.GetComponent<Rigidbody2D>().MovePosition(warpLocation.GetComponent<Transform>().localPosition);

        bIsOnGround = false;

        // (Slight Bug :- Can only teleport the warlock when the mouse is actively moving)

    }

}
