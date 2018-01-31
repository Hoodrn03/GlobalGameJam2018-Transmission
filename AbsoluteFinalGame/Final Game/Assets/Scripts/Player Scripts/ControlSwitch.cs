using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSwitch : MonoBehaviour {

    //---------------------------------------------------
    //                      Header 
    //
    //  This will be used to switch control between the
    //  main character and the mind controlled enemies. 
    //
    //---------------------------------------------------
    //              Data Members
    //---------------------------------------------------

    // This will be used to check if the player is currently controlling this character. 
    [SerializeField]
    private bool bIsControlled = false;

    // This will hold the value for the game object the script is connected to. 
    [SerializeField]
    private GameObject thisObject;

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
		

        if (bIsControlled == true)
        {
            thisObject.tag = "Player";

            // Player Layer

            thisObject.layer = 9;
        } 

        else if (thisObject.tag != "NPC")
        {
            thisObject.tag = "Enemy";

            // Enemy Layer 

            thisObject.layer = 8;
        }

	}

    // This will be used to gain control of the character the script is connected to.

    public void gainControl()
    {
        bIsControlled = true;
    }

    // This will be used to lose control of the character the script is connected to.

    public void loseControl()
    {
        // Debug.Log("Losing Control");

        bIsControlled = false;
    }

    // This will be used to check if the character is currently being mind controlled. 

    public bool getIsControlled()
    {
        return bIsControlled;
    }

}
