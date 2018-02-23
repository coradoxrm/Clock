using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Authored by Jett Lee
 */

public class fadeOutScript : MonoBehaviour {

    private float _fadeDuration = 2f;


    private void Awake()
    {
        StartCoroutine(fadeOut());
    }
    public void FadeToBlack()
    {
        //set start color
        SteamVR_Fade.Start(Color.clear, 0f);
        //set and start fade to
        SteamVR_Fade.Start(Color.black, _fadeDuration);
    }
    //private void FadeFromWhite()
    //{
    //    //set start color
    //    SteamVR_Fade.Start(Color.white, 0f);
    //    //set and start fade to
    //    SteamVR_Fade.Start(Color.clear, _fadeDuration);
    //}

    IEnumerator fadeOut()
    {
        yield return new WaitForSeconds(3f);
        FadeToBlack();
    }
}
