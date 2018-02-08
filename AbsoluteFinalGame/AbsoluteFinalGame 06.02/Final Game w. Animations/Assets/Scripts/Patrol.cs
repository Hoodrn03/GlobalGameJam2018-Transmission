using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour {

    [SerializeField]
    private Transform patrolPointOne;

    [SerializeField]
    private Transform patrolPointTwo;

    [SerializeField]
    private GameObject thisObject;

    [SerializeField]
    float travelSpeed = 0.01f;

    bool bMovingLeft = false;

    int count = 0;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        if (thisObject.GetComponent<Attac>().getAttacking() == false)
        {
            patrolCharacter();
        }
    }

    void patrolCharacter()
    {

        if (thisObject.transform.position.x <= patrolPointOne.position.x )
        {
            count += 2;
        }
        else if (thisObject.transform.position.x >= patrolPointTwo.position.x)
        {
            count -= 2; 
        }


        if (count > 0)
        {
            // Moving Left

            thisObject.transform.position = Vector3.MoveTowards(thisObject.transform.position, new Vector3(thisObject.transform.position.x + 0.05f, thisObject.transform.position.y, 0), 5);
        }

        else if (count < 0)
        {
            // Moving Right

            thisObject.transform.position = Vector3.MoveTowards(thisObject.transform.position, new Vector3(thisObject.transform.position.x - 0.05f, thisObject.transform.position.y, 0), 5);
        }
    }
}

