using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clockSound : MonoBehaviour {

    private static AudioSource audioSource;
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	}

    public static void playClockRotateSound()
    {
        AudioClip audioClip = Resources.Load<AudioClip>("rotateclock");
        audioSource.clip = audioClip;
        audioSource.Play();
    }

}
