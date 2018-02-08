using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarlockScript : MonoBehaviour {

    [SerializeField]
    private GameObject warlockCharacter;

    private ControlSwitch clControlSwitch;

    // Use this for initialization
    void Start () { 


    }
	
	// Update is called once per frame
	void Update ()
    {
        
        if (warlockCharacter.GetComponent<ControlSwitch>().getIsControlled() == false)
        {
            warlockCharacter.tag = "Warlock";
        }
  		
	}

}
