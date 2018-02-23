using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeDrawer : MonoBehaviour {
    public GameObject drawer;

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
		if (drawer.GetComponent<Drawer>().enabled == false)
        {
            drawer.GetComponent<Drawer>().enabled = true;
        }
	}
}
