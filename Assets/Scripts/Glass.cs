using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass : MonoBehaviour {
    Animator anim;
    AudioSource audioSource;

    public GameObject endingText;
    public GameObject stuff;

    private static AudioSource aerosmith;


    void Awake()
    {
        GameObject alice = GameObject.Find("endingScene-Character");
        anim = alice.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "myGlassWater")
        {
            //cheers animation
            anim.SetBool("cheers", true);

            //glass colliding sound
            if (audioSource)
                audioSource.Play();

            //ending canvas load

            AudioClip audioClip = Resources.Load<AudioClip>("Dontwannamissathing_fdein_fadeout");
            aerosmith = GameObject.Find("endingScene-Character").GetComponent<AudioSource>();
            aerosmith.clip = audioClip;
            aerosmith.volume = 0.6f;
            aerosmith.Play();
            StartCoroutine(DisplayText());
        }
    }

    IEnumerator DisplayText()
    {
        yield return new WaitForSeconds(5f);
        endingText.SetActive(true);
        yield return new WaitForSeconds(5f);
        endingText.SetActive(false);
        stuff.SetActive(true);

    }
}
