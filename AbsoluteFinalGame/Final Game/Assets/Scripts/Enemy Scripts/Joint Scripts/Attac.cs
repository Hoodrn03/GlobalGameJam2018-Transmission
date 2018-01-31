using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attac : MonoBehaviour
{
    //---------------------------------------------------
    //              Header 
    //
    //  This will be used to make the enemy attack the 
    //  player when they get too close to the enemy, 
    //  this script will also be used to restart the level 
    //  if the warlock is killed. 
    //
    //---------------------------------------------------
    //              Data Members
    //---------------------------------------------------

    // This will be used to reference the object the script is connected to.
    [SerializeField]
    GameObject thisObject;

    // This will be used to check if the enemy is attacking. 
    [SerializeField]
    bool attacking = false; 

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
		if (thisObject.GetComponent<ControlSwitch>().getIsControlled() == true)
        {
            attacking = false;
        }
	}

    // On Trigger Stay.

    private void OnTriggerStay2D(Collider2D collision)
    {
        

        // If the collider's name is Warlock 

        if (collision.name == "Warlock" && thisObject.GetComponent<ControlSwitch>().getIsControlled() == false)
        {

            // Debug.Log("Found You... You little...");
            
            // The enemy will move towards the player. 

            thisObject.transform.position = Vector3.MoveTowards(thisObject.transform.position, collision.transform.position, 1 * Time.deltaTime);

        }
    }

    // On Collision Enter. 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If the collider's name is Warlock

        if (collision.gameObject.name == "Warlock" && thisObject.GetComponent<ControlSwitch>().getIsControlled() == false)
        {
            // Debug.Log("Kill);

            // This will change the value of the attacking var to true.

            attacking = true;

            // Play attack anim. 

            // Kill Player. 

            collision.gameObject.GetComponent<WarlockScript>().playerDie();

        }
    }

    // On collision Exit 

    private void OnTriggerExit2D(Collider2D collision)
    {
        // If the collider with the name Warlock leaves the trigger.

        if (collision.gameObject.name == "Warlock")
        {
            // Debug.Log("Must be nothing...");

            // The var for attacking is set to false. 

            attacking = false;

        }
    }

    // Get attacking 

    public bool getAttacking()
    {
        // This will be used to check the value for attacking outside the script. 

        return attacking;
    }

}
