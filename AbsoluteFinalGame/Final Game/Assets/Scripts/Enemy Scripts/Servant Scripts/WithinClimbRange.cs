using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WithinClimbRange : MonoBehaviour {

    //---------------------------------------------------
    //                  Header 
    //
    //  This will be used to give the Servant unique 
    //  functionality. 
    //---------------------------------------------------
    //              Data Members
    //---------------------------------------------------

    [SerializeField]
    private bool bWithinClimbRange = false;

    [SerializeField]
    private GameObject currentServant;

    //---------------------------------------------------
    //              Member Functions 
    //---------------------------------------------------

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () { 

        if (currentServant != null)
        {
            if(bWithinClimbRange == true)
            {
                if (currentServant.GetComponent<Servant>().getIsActivated() == true)
                {
                    if (Input.GetKeyDown("e"))
                    {
                        // Debug.Log("Climbing");

                        currentServant.transform.position = Vector3.MoveTowards(currentServant.transform.position, this.transform.position, 10);
                    }
                }
            }
        }

	}

    // Enter Climb Range 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if(collision.name.Contains("servant"))
            {
                // Debug.Log("Servant within climb range");

                bWithinClimbRange = true;

                currentServant = collision.gameObject;
            }
        }
    }

    // Exit Climb Range 

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.name.Contains("servant"))
            {
                // Debug.Log("Servant Exited climb range");

                bWithinClimbRange = false;

                currentServant = null;
            }
        }
    }

    // Check if servant is within the climb range. 

    public bool checkIfWithinRange()
    {
        return bWithinClimbRange;
    }

}
