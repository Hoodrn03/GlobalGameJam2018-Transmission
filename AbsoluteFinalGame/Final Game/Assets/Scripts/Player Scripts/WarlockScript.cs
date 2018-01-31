using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarlockScript : MonoBehaviour {

    //---------------------------------------------------
    //                      Header 
    //
    //  This will be used to keep track of which object
    //  is the Warlock and contains key functions to 
    //  maintain the Warlock. 
    //
    //---------------------------------------------------
    //              Data Members
    //---------------------------------------------------

    // This will be the Warlock character. 
    [SerializeField]
    private GameObject warlockCharacter;

    // This will check if the warlock is currently the controlled character. 
    [SerializeField]
    private bool bWarlockControlled = true;

    // This will be used to keep track of the Warlock's health.
    [SerializeField]
    private float fHealth = 20;

    // This will be used to keep track of the Warlock's max health.
    [SerializeField]
    private const float fMaxHealth = 20;

    // This will be used as a constant cost for the use of the warp.
    [SerializeField]
    private const float fWarpCost = 2;

    // This will be used as a constant cost for the use of the mind control.
    [SerializeField]
    private const float fMindControlCost = 5;

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
        if (fHealth <= 0)
        {
            playerDie();
        }
	}

    // Cast Warp

    public void castWarp()
    {
        fHealth -= fWarpCost;
    }

    // Cast Mind Control

    public void castMindControl()
    {
        fHealth -= fMindControlCost;
    }

    // Get Current Health

    public float getCurrentHealth()
    {
        return fHealth;
    }

    // Player Die

    public void playerDie()
    {
        // Kill player 

        Debug.Log("You Found Da Way");
    }

    // Set Warlock Is Controlled

    public void setWarlockIsControlled(bool newValue)
    {
        bWarlockControlled = newValue;
    }

    public bool getWarlockIsControlled()
    {
        return bWarlockControlled;
    }

}
