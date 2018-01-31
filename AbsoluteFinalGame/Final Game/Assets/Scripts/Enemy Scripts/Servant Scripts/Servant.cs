using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Servant : MonoBehaviour {

    //---------------------------------------------------
    //                  Header 
    //
    //  This will be used to give the Servant unique 
    //  functionality. 
    //---------------------------------------------------
    //              Data Members
    //---------------------------------------------------

    [SerializeField]
    private bool bSeravntActivated = false;

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
        activateSeravnt();
	}

    // Activate Servant 

    public void activateSeravnt()
    {
        if (Input.GetKeyDown("e"))
        {
            if (thisObject.GetComponent<ControlSwitch>().getIsControlled() == true)
            {
                bSeravntActivated = true;

                // Debug.Log("Servant is Ready");
            }
        }
        else if (thisObject.GetComponent<ControlSwitch>().getIsControlled() == false)
        {
            bSeravntActivated = false; 
        }
    }

    // Climb On Servant. 

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Warlock")
        {
            if (bSeravntActivated == true)
            {
                // Debug.Log("activated");

                collision.transform.position = thisObject.transform.position + new Vector3(0, 2, 0);
            }
        }
    }

    // Check if seravnt is activated. 

    public bool getIsActivated()
    {
        return bSeravntActivated;
    }

}
