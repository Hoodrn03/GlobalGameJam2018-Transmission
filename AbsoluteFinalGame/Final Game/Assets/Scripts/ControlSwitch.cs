using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSwitch : MonoBehaviour {

    // This will be used to check if the player is currently controlling this character. 
    [SerializeField]
    private bool bIsControlled = false;

    [SerializeField]
    private bool bIsControlable = true; 

    // This will hold the value for the game object the script is connected to. 
    [SerializeField]
    private GameObject thisObject;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		

        if (bIsControlled == true)
        {
            thisObject.tag = "Player";
        } 

        else if (thisObject.name == "Warlock")
        {
            thisObject.tag = "Warlock";
        }

        else if (thisObject.tag != "NPC")
        {
            thisObject.tag = "Enemy";
        }

        else
        {

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

    public bool getIsControllable()
    {
        return bIsControlable;
    }

}
