using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {


    [SerializeField]
    private GameObject tempObject;

	public void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.tag == "Warlock")
        {
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<CurrentLevel>().setCurrentLevel(GameObject.FindGameObjectWithTag("GameManager").GetComponent<CurrentLevel>().getCurrentLevel() + 1);

            if (GameObject.FindGameObjectWithTag("GameManager").GetComponent<CurrentLevel>().getCurrentLevel() >= 4)
            {
                SceneManager.LoadScene("MainMenu");
            }
            else
            {
                SceneManager.LoadScene("level_" + GameObject.FindGameObjectWithTag("GameManager").GetComponent<CurrentLevel>().getCurrentLevel());
            }
        }
	}

}
