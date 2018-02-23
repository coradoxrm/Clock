using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Authored by Miao Ren
 */

public class Frame : MonoBehaviour {

    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;

    private static AudioSource audioSource;

    void Awake () {
        audioSource = GetComponent<AudioSource>();
    }
	
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "code1" && other.transform.parent == null)
        {
            other.gameObject.SetActive(false);
            p1.SetActive(true);
            audioSource.Play();
        }
        if (other.gameObject.name == "code2" && other.transform.parent == null)
        {
            other.gameObject.SetActive(false);
            p2.SetActive(true);
            audioSource.Play();
        }
        if (other.gameObject.name == "code3" && other.transform.parent == null)
        {
            other.gameObject.SetActive(false);
            p3.SetActive(true);
            audioSource.Play();
        }
        if (other.gameObject.name == "code4" && other.transform.parent == null)
        {
            other.gameObject.SetActive(false);
            p4.SetActive(true);
            audioSource.Play();
        }
    }
}
