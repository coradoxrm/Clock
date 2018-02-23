using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Authored by Miao Ren
 */

public class Drawer : MonoBehaviour {

	public bool isLocked;
	public float min;
	public float max;

    private void Start()
    {
        max = transform.position.z;
    }

    void Update () {
		if (isLocked) {
			transform.position = new Vector3 (transform.position.x, transform.position.y, max);
		} else {
            transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Clamp(transform.position.z, min, max));
		}
			
	}

}
