using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Authored by Miao Ren
 */

public class Keyhole : MonoBehaviour {
    public GameObject key;
    public Drawer drawer;

    //void OnTriggerEnter(Collider other)
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "key" && other.transform.parent == null)
        {
            other.gameObject.SetActive(false);
            key.SetActive(true);
            StartCoroutine(Rotate());
        }
    }

    IEnumerator Rotate()
    {
        for (int i = 0; i < 90; i++)
        {
            transform.Rotate(new Vector3(-1, 0, 0));
            yield return null;
        }
        drawer.isLocked = false;
        yield break;
    }
}
