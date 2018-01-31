using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    //---------------------------------------------------
    //                  Header 
    //
    //  This will be used to check wheather the knight is
    //  within the rage of the door to use it. 
    //
    //---------------------------------------------------
    //              Data Members
    //---------------------------------------------------

    [SerializeField]
    private bool bKnightWithinRange;

    [SerializeField]
    private GameObject currentKnight;

    [SerializeField]
    private GameObject thisObject;

    [SerializeField]
    private bool doorOpen;

    //---------------------------------------------------
    //              Member Functions 
    //---------------------------------------------------

    // Use this for initialization

    void Start () {
		
	}
	
	// Update is called once per frame

	void Update ()
    {

        // If the current game object isn't currently null.

        if (currentKnight != null)
        {
            // If the knight has been activated and it is within the range of the door.

            if (currentKnight.GetComponent<Knight>().getKnightActivated() == true && bKnightWithinRange == true)
            {
                // Toggle the door between open and close. 

                doorOpen = !doorOpen;

                // Debug.Log("*Click...*");
            }
        }

        // If the door is currently open. 

        if (doorOpen == true)
        {
            // Disable the door's collider.

            thisObject.GetComponent<Collider2D>().enabled = false;

            // Disable the door's sprite renderer. 

            thisObject.GetComponent<SpriteRenderer>().enabled = false;
        }

        else
        {
            // Enable the door's collider.

            thisObject.GetComponent<Collider2D>().enabled = true;

            // Enable the door's sprite renderer. 

            thisObject.GetComponent<SpriteRenderer>().enabled = true;
        }

	}

    // Knight Enter 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(collision.name.Contains("knight"))
            {
                // Debug.Log("Knight at your service");

                bKnightWithinRange = true;

                currentKnight = collision.gameObject;
            }
        }
    }

    // Knight Exit

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Enemy")
        {
            if (collision.name.Contains("knight"))
            {
                // Debug.Log("*Knight leaves range of door*");

                bKnightWithinRange = false;

                currentKnight = null;
            }
        }
    }
}
