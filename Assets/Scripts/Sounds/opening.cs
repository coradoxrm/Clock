using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class opening : MonoBehaviour {

    Animator anim;

    private static AudioSource audioSource;
	// Use this for initialization
	void Start () {
        
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(playOpening());
	}
	
	// Update is called once per frame
	void Update () {
        //if (!audioSource.isPlaying)
        //{
        //    SceneManager.LoadScene("Game");
        //}
	}

    IEnumerator playOpening()
    {
        yield return new WaitForSeconds(10f);
        audioSource.Play();

        yield return new WaitForSeconds(15f);
        SceneManager.LoadScene("Game");
    }
}
