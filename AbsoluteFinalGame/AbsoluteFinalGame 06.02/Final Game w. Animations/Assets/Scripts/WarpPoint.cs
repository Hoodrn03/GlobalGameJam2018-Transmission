using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpPoint : MonoBehaviour {

    // This will be used to reference the warp location game object. 
    [SerializeField]
    private GameObject WarpLoct;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

       // This will used to limit the mouse's possition to within the game window.
       Vector3 WarpPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       WarpPoint.z = 0;
       gameObject.transform.position = WarpPoint;
	}
}
