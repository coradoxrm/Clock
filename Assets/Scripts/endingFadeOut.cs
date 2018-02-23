using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endingFadeOut : MonoBehaviour {

    private float _fadeDuration = 5.0f;
    // Use this for initialization
    void Awake () {
        StartCoroutine(fadeIn());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void BlackToNow()
    {
        //set start color
        SteamVR_Fade.Start(Color.black, 0f);
        //set and start fade to
        SteamVR_Fade.Start(Color.clear, _fadeDuration);
    }

    IEnumerator fadeIn()
    {
        yield return new WaitForSeconds(0.1f);
        BlackToNow();
    }
}
