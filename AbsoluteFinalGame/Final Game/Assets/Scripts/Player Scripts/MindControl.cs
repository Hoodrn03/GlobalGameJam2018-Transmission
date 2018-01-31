using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MindControl : MonoBehaviour {

    //---------------------------------------------------
    //              Header 
    //
    //  This will be used to shoot a projectile from the 
    //  Warlock towards the mouse's possition allowing 
    //  for them to take control of a mind controlable 
    //  enemy if it hits them. 
    //
    //---------------------------------------------------
    //              Data Members
    //---------------------------------------------------

    // This will be used to reference the Warlock Game Object.
    [SerializeField]
    private GameObject masterWarlock;

    // This will be used to reference the mouse pos.
    [SerializeField]
    private GameObject mousePos;

    // This will be used to refernce the projectile which will be shot.
    [SerializeField]
    private Rigidbody2D projectile;

    // This will be used to limit the number of projectiles within the game world to only one. 
    [SerializeField]
    private bool bHasShot = false;

    // This will be used to clone the projectile. 
    [SerializeField]
    private Rigidbody2D clone;

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
        // This will be used to check weather the Warlock is in control or not. 

            // If there is no game object with the tag projectile.

            if (!GameObject.FindGameObjectWithTag("Projectile"))
            {
                // The Warlock currently hasn't shot. 

                bHasShot = false;
            }

            // If they are in control then when they press the Right mouse button.

            if (Input.GetMouseButtonDown(1))
            {
            // The Shoot beam funtion will be called.

                if (masterWarlock.GetComponent<WarlockScript>().getWarlockIsControlled() == true)
                {
                    shootBeam();
                }
            }
        

	}

    // Shoot Beam.

    void shootBeam()
    {
        // Debug.Log("Shoot");

        // If there currently isn't a projectile in the game world.

        if (bHasShot != true)
        {
            // This will instantiate a new rigidbody2D to the rigidBody2D clone. 

            clone = (Rigidbody2D)Instantiate(projectile, masterWarlock.transform.position, Quaternion.identity) as Rigidbody2D;

            masterWarlock.GetComponent<WarlockScript>().castMindControl();

            // This prevents the Warlock from shooting more than one projectile. 

            bHasShot = true;
        } 
    }



}
