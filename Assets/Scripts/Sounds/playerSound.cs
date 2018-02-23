using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSound : MonoBehaviour {

    private static AudioSource audioSource;
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

	}

    public static void playMurderBGM()
    {
        AudioClip audioClip = Resources.Load<AudioClip>("12");
        audioSource.clip = audioClip;
        audioSource.Play();
        audioSource.loop = true;
    }

    public static void playBackBGM()
    {
        AudioClip audioClip = Resources.Load<AudioClip>("8-9-10");
        audioSource.clip = audioClip;
        audioSource.Play();
        audioSource.loop = true;
    }

    public static void playHintBGM()
    {
        AudioClip audioClip = Resources.Load<AudioClip>("11am");
        audioSource.clip = audioClip;
        audioSource.Play();
        audioSource.loop = true;

    }

    public static void playFinishBGM()
    {
        AudioClip audioClip = Resources.Load<AudioClip>("12puzzlecomplete_01");
        audioSource.clip = audioClip;
        audioSource.Play();
        audioSource.loop = true;
    }
}
