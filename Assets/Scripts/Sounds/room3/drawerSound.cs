using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawerSound : MonoBehaviour {

    private static AudioSource audioSource;
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        AudioClip audioClip = Resources.Load<AudioClip>("draweropen");
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    private void OnCollisionExit(Collision collision)
    {
        AudioClip audioClip = Resources.Load<AudioClip>("drawer_close");
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
