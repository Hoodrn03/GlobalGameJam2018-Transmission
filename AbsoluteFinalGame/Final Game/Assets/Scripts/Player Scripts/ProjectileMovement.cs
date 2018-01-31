using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour {

    //---------------------------------------------------
    //                      Header 
    //
    //  This will be used to control the movement of the 
    //  projectile, It will also trigger the control switch 
    //  when it collides with a mind controlable enemy.  
    //
    //---------------------------------------------------
    //              Data Members
    //---------------------------------------------------

    // This will be used to check if the projectile has hit a wall.
    [SerializeField]
    private bool bHitWall = false;

    // This will be used to check if the projectile has hit an enemy.
    [SerializeField]
    private bool bHitEnemy = false;

    // This will be used to refernce the current collision target.
    [SerializeField]
    private GameObject currentCol;

    // This will be used to refernce the projectile this script is conncted to. 
    [SerializeField]
    private GameObject thisObject;

    // This will be used to reference the Warlock character.
    [SerializeField]
    private GameObject warlockCharacter;

    // This will be used to contain the mouse's possition upon the projectile's initalization. 
    [SerializeField]
    private Vector3 currentMousePos;

    //---------------------------------------------------
    //              Member Functions
    //---------------------------------------------------

    // Use this for initialization

    void Start ()
    {
        // Debug.Log("Projectile Created");
        
        // This will be used to get the mouse's possition when the attatched object enters the game world. 

        currentMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    }
	
	// Update is called once per frame

	void Update ()
    {
        // This will move the projectile towards the possition the mouse was at when the projectile was initalized.

        thisObject.transform.position = Vector3.MoveTowards(thisObject.transform.position, currentMousePos, 1);

        // If the projectile reaches its final destination before hitting something.

        if (thisObject.transform.position == currentMousePos)
        {
            // Debug.Log("Reached Final Destination...");

            // The projectile will be destroyed. 

            Destroy(thisObject);
        }

    }

    // Projectile Collision

    private void OnTriggerEnter2D(Collider2D collision)
    {

        // Debug.Log("Hit");

        // If the projectile hits something : 

        if (collision.gameObject.tag == "Platforms")
        {
            // Hits Wall.

            bHitWall = true;

            // Debug.Log("Hit Platforms");

            Destroy(thisObject);
        }

        else if (collision.gameObject.tag == "Enemy")
        {
            // Hits Enemy.

            bHitEnemy = true;

            // Sets the value of currentCol to the most recent collision object.

            currentCol = collision.gameObject;

            // Calls the controlSwith class from the collision target. 

            currentCol.GetComponent<ControlSwitch>().gainControl();

            // Debug.Log("Hit Enemy");

            Destroy(thisObject);
        }

        else if (collision.gameObject.tag == "NPC")
        {
            // Hits NPC

            // Debug.Log("Hit NPC");

            Destroy(thisObject);
        }

    }

    // Get hit Wall

    public bool getHitWall()
    {
        return bHitWall;
    }

    // Get Hit Enemy

    public bool getHitEnemy()
    {
        return bHitEnemy;
    }

    // Get Current Collision Target

    public GameObject getCurrentCol()
    {
        return currentCol;
    }


}
