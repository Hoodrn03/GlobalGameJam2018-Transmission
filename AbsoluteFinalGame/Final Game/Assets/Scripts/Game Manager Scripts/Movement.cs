using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    //---------------------------------------------------
    //                  Header 
    //
    //  This will be used to allow for the player to move 
    //  any character that they currently control.
    //
    //---------------------------------------------------
    //              Data Members
    //---------------------------------------------------

    // This will be used to check if the player is holding down the D Key.
    [SerializeField]
    private bool bIsMovingRight = false;

    // This will be the constant speed of the player. 
    [SerializeField]
    private const float fSpeed = 5.0f;

    // This will make te player fall at a constant rate. 
    [SerializeField]
    private const float gravity = -4.81f;

    // This will be the object the script is connected to. 
    [SerializeField]
    private GameObject connectedObject;

    //---------------------------------------------------
    //              Member Functions 
    //---------------------------------------------------

    // Use this for initialization
    void Start () {    

	}

    // Update is called once per frame

    void Update()
    {

        // This looks for a game object tagged with Player.

        connectedObject = GameObject.FindGameObjectWithTag("Player");

        if (!GameObject.FindGameObjectWithTag("Player"))
        {
            // If there are not objects tagged with Player, it will look for an object tagged with Warlock.

            connectedObject = GameObject.FindGameObjectWithTag("Warlock");
        }

        if (connectedObject != null)
        {

            checkControl();

            // This will use the defined movement keys to allow for the controlled player to move. 

            if (Input.GetAxis("Horizontal") != 0)
            {
                connectedObject.GetComponent<Rigidbody2D>().velocity = new Vector2(fSpeed * Input.GetAxis("Horizontal"), gravity);
            }

            // This will be used to relinquish control of the enemy which is controlled. 

            if (Input.GetMouseButton(2))
            {
                if (connectedObject.tag != "Warlock")
                {
                    connectedObject.GetComponent<ControlSwitch>().loseControl();
                }

                // Debug.Log("Removing Control");
            }
        }
    }

    // Check Control

    public void checkControl()
    {
        if (connectedObject.tag == "Warlock")
        {
            connectedObject.GetComponent<WarlockScript>().setWarlockIsControlled(true);
        }

        else if (connectedObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Warlock").GetComponent<WarlockScript>().setWarlockIsControlled(false);
        }
    }

}
