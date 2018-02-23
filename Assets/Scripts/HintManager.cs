using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Authored by Miao Ren
 */

public class HintManager : MonoBehaviour {

    public static int status; //game status
    //0 - alarm
    //1 - file
    //2 - phone
    public static bool startFade = false;
    
    //phase debug
    public bool alarm_done;
    public bool file_done;
    public bool phone_done;

    //11am settings
    public GameObject alarm_hint;
    public GameObject file_hint;
    public GameObject phone_hint;
    public GameObject leave_hint;
    public GameObject roomEnding;
    public GameObject roomMurder;

    //character B knock at door
    public AudioSource finishSceneSpeaker;

    void Start () {
        status = 0;
    }

    //state machine
    void Update()
    {
        if (status == 0)
        {
            if (alarm_done)
            {
                alarm_hint.SetActive(false);
                file_hint.SetActive(true);
                phone_hint.SetActive(false);
                leave_hint.SetActive(false);

                status = 1;
            }
        }

        if (status == 1)
        {
            if (file_done)
            {
                alarm_hint.SetActive(false);
                file_hint.SetActive(false);
                phone_hint.SetActive(true);
                leave_hint.SetActive(false);
                status = 2;
            }
        }

        if (status == 2)
        {
            if (phone_done)
            {
                alarm_hint.SetActive(false);
                file_hint.SetActive(false);
                phone_hint.SetActive(false);
                leave_hint.SetActive(true);
                status = 3;
                roomMurder.SetActive(false);
                roomEnding.SetActive(true);
            }
        }

        if (status == 3 && Clock.time == 12)
        {
            StartCoroutine(SceneChange());
            status = 4;
        }
    }


    IEnumerator SceneChange()
    {
        yield return new WaitForSeconds(3f);
        finishSceneSpeaker.Play();
        yield return new WaitForSeconds(4f);
        finishSceneSpeaker.Play();
        yield return new WaitForSeconds(3f);
        startFade = true;
        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene("Ending");
    }
}
