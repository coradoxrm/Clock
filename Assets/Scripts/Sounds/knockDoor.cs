using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class knockDoor : MonoBehaviour {

    private static AudioSource audioSource;
    private float currentTime = 0.0f;
	// Use this for initialization
	void Awake () {
        //audioSource.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        currentTime += Time.deltaTime;

        if (currentTime > 5.0f)
        {
            currentTime = -10000000f;
            audioSource.Play();
            StartCoroutine(sceneEnd());
        }
	}

    IEnumerator sceneEnd()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Ending");
    }
}
