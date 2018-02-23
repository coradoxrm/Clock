using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class SafeBoxDoor : MonoBehaviour {

    public Wheel w1;
    public Wheel w2;
    public Wheel w3;

    public GameObject importantFile;
    private static AudioSource doorAudio;

    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
        doorAudio = GetComponent<AudioSource>();
    }

    void Update () {
        if(w1.num == 5 && w2.num == 6 && w3.num == 3 ) // passcode = 5/6/3 (from the piece puzzle)
        {
            //Debug.Log("open && play sound");
            importantFile.SetActive(true);
            anim.SetTrigger("open");
            w1.num = w2.num = w3.num = 0;
            doorAudio.Play();
        }
	}
}
