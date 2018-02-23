using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour {

    public static UnityStandardAssets.ImageEffects.ColorCorrectionCurves script;
    private float _fadeDuration = 5.0f;

    // Use this for initialization
    void Awake () {
        script = GetComponent<UnityStandardAssets.ImageEffects.ColorCorrectionCurves>();
    }
	
	// Update is called once per frame
	void Update () {
        if (HintManager.startFade)
        {
            StartCoroutine(testFade());
            HintManager.startFade = false;
        }
	}

    private void FadeToBlack()
    {
        //set start color
        SteamVR_Fade.Start(Color.clear, 0f);
        //set and start fade to
        SteamVR_Fade.Start(Color.black, _fadeDuration);
    }

    IEnumerator testFade()
    {
        yield return new WaitForSeconds(0.1f);
        FadeToBlack();
    }
}
