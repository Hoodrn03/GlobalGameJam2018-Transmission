using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentLevel : MonoBehaviour {

    [SerializeField]
    private static int currentLevel = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log(currentLevel);
	}

    // Get Current Level.

    public int getCurrentLevel()
    {
        return currentLevel;
    }

    // Set Current level. 

    public void setCurrentLevel(int newCurrentLevel)
    {
        currentLevel = newCurrentLevel;
    }




}
