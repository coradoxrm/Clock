using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Authored by Miao Ren
 */

public class Alarm : MonoBehaviour {

    public GameObject battery_1;
    public GameObject battery_2;
    public GameObject screen;
    public Material m;

    public HintManager hint;
    private bool alarmed = false;

    private static AudioSource audioSource;

    void Awake () {
        audioSource = GetComponent<AudioSource>();
    }
	
	void Update () {
        if(battery_1.activeSelf && battery_2.activeSelf)
        {
            hint.alarm_done = true;
        }
	}

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "battery1" && other.transform.parent == null)
        {
            other.gameObject.SetActive(false);
            battery_1.SetActive(true);
            AudioClip audioClip = Resources.Load<AudioClip>("pickup");
            audioSource.clip = audioClip;
            audioSource.Play();
        }
        if (other.gameObject.name == "battery2" && other.transform.parent == null)
        {
            other.gameObject.SetActive(false);
            battery_2.SetActive(true);
            AudioClip audioClip = Resources.Load<AudioClip>("pickup");
            audioSource.clip = audioClip;
            audioSource.Play();
        }

        if (!alarmed && battery_1.activeSelf && battery_2.activeSelf)
        {
            alarmed = true;
            AudioClip audioClip = Resources.Load<AudioClip>("alarmclock");
            audioSource.clip = audioClip;
            audioSource.Play();
            screen.GetComponent<Renderer>().material = m;
        }
    }
}
