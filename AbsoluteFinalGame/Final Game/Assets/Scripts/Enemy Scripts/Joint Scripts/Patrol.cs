using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    //---------------------------------------------------
    //                  Header 
    //
    //  This script will be used to make the attached 
    //  character to move between two points created 
    //  within the game world. 
    //
    //---------------------------------------------------
    //              Data Members
    //---------------------------------------------------

    // This will be used to set the leftmost patrol point.
    [SerializeField]
    private Transform patrolPointLeft;
    
    // This will be used to set the rightmost patrol point;
    [SerializeField]
    private Transform patrolPointRight;

    // This will be used to reference the object the script is connected to.
    [SerializeField]
    private GameObject thisObject;

    // This will be used to designate the speed in which the enemy ill move while patrolling. 
    [SerializeField]
    private float travelSpeed = 0.5f;

    // This will be used to see if the enemy is currently moving left or right. 
    [SerializeField]
    private bool bMovingLeft = false;

    //---------------------------------------------------
    //              Member Functions
    //---------------------------------------------------

    // Use this for initialization

    void Start()
    {

    }

    // Update is called once per frame

    void Update()
    {
        // If the component connected to this object (Attac script) returns that the enemy is not currently
        // chasing/attacking the player it will patrol. 

        if (thisObject.GetComponent<Attac>().getAttacking() == false && thisObject.GetComponent<ControlSwitch>().getIsControlled() == false)
        { 
            patrolCharacter();
        }
    }

    // Partol Character. 

    void patrolCharacter()
    {

        // This will make the connected object move between two seperate points within the world. 

        if (bMovingLeft == true)
        {
            // Moving Left

            thisObject.transform.Translate(Vector3.left * travelSpeed * Time.deltaTime);
        }
        else
        {
            // Moving Right

            thisObject.transform.Translate(Vector3.right * travelSpeed * Time.deltaTime);
        }



        // Check if this object has touched their patrol points. 

        if (thisObject.transform.position.x <= patrolPointLeft.position.x)
        {
            // If this object's x possition is less then or equal to the left patrol point begin to move right.

            bMovingLeft = false;
        }

        else if (thisObject.transform.position.x >= patrolPointRight.position.x)
        {
            // If this object's x possition is less then or equal to the right patrol point begin to move left.

            bMovingLeft = true;
        }

    }
}

