using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attac : MonoBehaviour {

    [SerializeField]
    GameObject thisObject;

    [SerializeField]
    bool attacking = false; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
            if (collision.name == "Warlock")
            {
                thisObject.transform.position = Vector3.MoveTowards(thisObject.transform.position, collision.transform.position, 1 * Time.deltaTime);

                attacking = true;
            }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Warlock")
        {
            // Kill Player. 

            Debug.Log("Kill, Kill, Kill... Good Dog");

        }
    }

    private void OnCollisionExit(Collision collision)
    {

        if (collision.gameObject.name == "Warlock")
        {
            // Kill Player. 

            Debug.Log("Must be nothing...");

            attacking = false;

        }
    }

    public bool getAttacking()
    {
        return attacking;
    }

}
