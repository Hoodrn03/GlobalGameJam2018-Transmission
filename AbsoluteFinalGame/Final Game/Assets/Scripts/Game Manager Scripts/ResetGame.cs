using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGame : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<CurrentLevel>().setCurrentLevel(1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
