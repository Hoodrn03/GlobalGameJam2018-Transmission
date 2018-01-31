using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour {

    //---------------------------------------------------
    //                  Header 
    //
    //  This will be used to give the Knight unique 
    //  functionality. 
    //---------------------------------------------------
    //              Data Members
    //---------------------------------------------------

    [SerializeField]
    private bool bKnightActivated = false;

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
        if (Input.GetKeyDown("e"))
        {
            if (thisObject.GetComponent<ControlSwitch>().getIsControlled() == true)
            {
                // Debug.Log("E Pressed while under control");

                bKnightActivated = true;
            }
        }	

        else
        {
            bKnightActivated = false;
        }
	}

    // Get Knight Activate

    public bool getKnightActivated()
    {
        return bKnightActivated;
    }

    // Collide With Guard Monster

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (bKnightActivated == true && collision.gameObject.tag == "NPC")
        {
            // Attack 

            // Debug.Log("Knight Attack");

            // Debug.Log("Kill Guard Monster");

            Destroy(collision.gameObject);
        }

    }
}
