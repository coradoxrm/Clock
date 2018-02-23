using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingAnim : MonoBehaviour {
    Animator anim;

    private AudioSource audioSource;

    // Use this for initialization
    void Awake()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(End());
    }

    IEnumerator End()
    {
        //yield return new WaitForSeconds(2f);

        //speaking


        if (audioSource)
        {
            audioSource.Play();
        }


        //wait for speaking
        yield return new WaitForSeconds(39f);

        //endspeak
        anim.SetBool("endSpeaking", true);
    }

}
