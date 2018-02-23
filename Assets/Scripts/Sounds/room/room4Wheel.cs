using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class room4Wheel : MonoBehaviour {

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
        AudioClip audioClip = Resources.Load<AudioClip>("safebox_numberlock");
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
