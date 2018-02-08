using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MindControl : MonoBehaviour {

    [SerializeField]
    private GameObject masterWarlock;

    [SerializeField]
    private GameObject mousePos;

    [SerializeField]
    private Rigidbody2D projectile;

    [SerializeField]
    private bool bFacingLeft = false;

    [SerializeField]
    private float fOriginOffset = 1.0f;

    [SerializeField]
    private float fDistance = 600.0f;

    [SerializeField]
    private GameObject hitTarget;

    [SerializeField]
    private bool bHasShot = false;

    [SerializeField]
    private Rigidbody2D clone;

    // Use this for initialization
    void Start () {
		


	}
	
	// Update is called once per frame
	void Update ()
    {
        if (masterWarlock.GetComponent<ControlSwitch>().getIsControlled() == true)
        {

            if (Input.GetMouseButtonDown(1))
            {
                shootBeam();
            }

            if (!GameObject.FindGameObjectWithTag("Projectile"))
            {
                bHasShot = false;
            }
        }

	}

    void shootBeam()
    {
        Debug.Log("Shoot");

        if (bHasShot != true)
        {

            clone = (Rigidbody2D)Instantiate(projectile, masterWarlock.transform.position, Quaternion.identity) as Rigidbody2D;

            bHasShot = true;
        } 
    }



}
