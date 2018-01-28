using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel3 : MonoBehaviour {



	public void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.tag == "Player")
		{
			SceneManager.LoadScene("level_3");
		}
	}

}
