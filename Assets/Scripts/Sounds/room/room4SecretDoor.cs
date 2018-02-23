using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class room4SecretDoor : MonoBehaviour {

    private static AudioSource audioSource;
    private static bool doorOpen = false;
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (!doorOpen)
        {
            AudioClip audioClip = Resources.Load<AudioClip>("doorcreak_safebox");
            audioSource.clip = audioClip;
            audioSource.Play();
        }

        if (doorOpen)
        {
            AudioClip audioClip = Resources.Load<AudioClip>("doorcreakandclose");
            audioSource.clip = audioClip;
            audioSource.Play();
        }

    }
}
