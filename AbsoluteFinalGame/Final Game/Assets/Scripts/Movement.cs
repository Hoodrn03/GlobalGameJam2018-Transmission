using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    // This will be used to check if the player is holding down the D Key.
    [SerializeField]
    private bool bIsMovingRight = false;

    // This will be the constant speed of the player. 
    [SerializeField]
    private const float fSpeed = 5.0f;

    [SerializeField]
    private const float gravity = -4.81f;

    // This will be the object the script is connected to. 
    [SerializeField]
    private GameObject connectedObject;

	// Use this for initialization
	void Start () {

        

	}
	
	// Update is called once per frame
	void Update ()
    {

        if (connectedObject = GameObject.FindGameObjectWithTag("Player"))
        {
            
        }

        else 
        {
            connectedObject = GameObject.FindGameObjectWithTag("Warlock");

            connectedObject.GetComponent<ControlSwitch>().gainControl();

            // Debug.Log("Warlock Regaining Control");
        }

        if (Input.GetMouseButton(2))
        {
            connectedObject.GetComponent<ControlSwitch>().loseControl();
        }


        if (Input.GetAxis("Horizontal") != 0)
        {
            connectedObject.GetComponent<Rigidbody2D>().velocity = new Vector2(fSpeed * Input.GetAxis("Horizontal"), gravity);
        }
	}

}
