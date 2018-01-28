using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour {

    [SerializeField]
    bool bHitWall = false;

    [SerializeField]
    bool bHitEnemy = false;

    [SerializeField]
    GameObject currentCol;

    [SerializeField]
    GameObject thisObject;

    float countdown = (float) 2;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        thisObject.transform.position = Vector3.MoveTowards(thisObject.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), 0.75f);

        countdown -= Time.deltaTime;

        if (countdown < 0)
        {
            countdown = 2;

            Destroy(thisObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit");

        if (collision.gameObject.tag == "Platforms")
        {
            bHitWall = true;

            // Debug.Log("Hit Platforms");

            Destroy(thisObject);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            bHitWall = true;

            currentCol = collision.gameObject;

            currentCol.GetComponent<ControlSwitch>().gainControl();

            //  Debug.Log("Hit Enemy");

            Destroy(thisObject);
        }

        else if (collision.gameObject.tag == "NPC")
        {
            // Debug.Log("Hit NPC");

            Destroy(thisObject);
        }
    }

    public bool getHitWall()
    {
        return bHitWall;
    }

    public bool getHitEnemy()
    {
        return bHitEnemy;
    }

    public GameObject getCurrentCol()
    {
        return currentCol;
    }


}
