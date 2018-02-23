using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Authored by Miao Ren
 */

public class ClockKeyhole : MonoBehaviour {

	public GameObject clockKey;
	public Clock left;
	public Clock right;

    private GameObject clockInterface;
    public static bool isActive = false;
    public Material texture12;
    public GameObject hint;

    Animator animator;

    private static AudioSource audioSource;

    private void Awake()
    {
        animator = GameObject.Find("timeClock").GetComponent<Animator>();
        clockInterface = GameObject.Find("TimeClockInterface");
        audioSource = GetComponent<AudioSource>();
    }


    void OnTriggerStay(Collider other)
	{
		if (other.gameObject.name == "TimeClock-springKey" && other.transform.parent == null)
		{
			other.gameObject.SetActive(false);
			clockKey.SetActive(true);

            StartCoroutine(Rotate());
            AudioClip audioClip = Resources.Load<AudioClip>("activateclock");
            audioSource.clip = audioClip;
            audioSource.Play();
            animator.SetTrigger("activate");
            StartCoroutine(WaitAndActive());

        }

	}

    IEnumerator Rotate()
    {
        for (int i = 0; i < 90; i++)
        {
            transform.Rotate(new Vector3(-1, 0, 0));
            yield return 0;
        }
    }

    IEnumerator WaitAndActive() 
    {
        yield return new WaitForSeconds(2.5f);
        //yield return new WaitForSeconds(1.5f);
        animator.enabled = false;
        left.isActive = true;
        right.isActive = true;
        hint.SetActive(true);
        clockInterface.GetComponent<Renderer>().material = texture12;
        isActive = true;
    }
}
