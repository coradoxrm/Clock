using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class movie : MonoBehaviour {
    MovieTexture mt;
    RectTransform rt;
    Vector2 origPos;
    // Use this for initialization
    void Start () {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<VideoPlayer>().Stop();
        StartCoroutine(Example());

    }

    IEnumerator Example()
    {
        yield return new WaitForSeconds(1f);
        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<VideoPlayer>().Play();
        yield return new WaitForSeconds(16f);
        //GetComponent<MeshRenderer>().enabled = false;
        GetComponent<VideoPlayer>().Stop();
    }
    }
