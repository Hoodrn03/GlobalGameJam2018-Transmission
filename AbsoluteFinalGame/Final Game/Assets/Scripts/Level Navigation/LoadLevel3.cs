using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel3 : MonoBehaviour {



	public void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.tag == "Warlock")
		{
			SceneManager.LoadScene("level_" + GameObject.FindGameObjectWithTag("GameManager").GetComponent<CurrentLevel>().getCurrentLevel() + 1);
		}
	}

}
