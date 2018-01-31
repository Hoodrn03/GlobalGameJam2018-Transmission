using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpPoint : MonoBehaviour {

    //---------------------------------------------------
    //                      Header 
    //
    //  This will be used to keep track of the mouse's 
    //  possition.                        
    //
    //---------------------------------------------------
    //              Data Members
    //---------------------------------------------------

    // This will be used to reference the warp location game object. 
    [SerializeField]
    private GameObject WarpLoct;

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

        // This will used to limit the mouse's possition to within the game window.
        Vector3 WarpPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        WarpPoint.z = 0;

        // This will move the empty game object to the mouse's possition.

        gameObject.transform.position = WarpPoint;
	}
}
