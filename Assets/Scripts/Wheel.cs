using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Authored by Miao Ren
 */

public class Wheel : MonoBehaviour {

	Vector3 targetAngle;
    private AudioSource audioSource;

    private Vector3 currentAngle;
    bool rotating = false;

    public int num = 1;
    float speed = 10f;


    void Start()
    {
        transform.eulerAngles = new Vector3(-90f, 0f, -180f);
        currentAngle = transform.eulerAngles;
        audioSource = GetComponent<AudioSource>();
    }

	public void StartRotate() {
		rotating = true;
		num += 1;
        audioSource.Play();

		if (num > 7) {
			num = 0;
		}   

		targetAngle = new Vector3((num-1) * 45f - 90f, 0f, -180f);
	}

    public void Update()
    {
        if (rotating)
        {
            currentAngle = new Vector3(
            Mathf.LerpAngle(currentAngle.x, targetAngle.x, Time.deltaTime*speed),
            0f,
            -180f);

            transform.eulerAngles = currentAngle;

            if(transform.eulerAngles == targetAngle)
            {
                rotating = false;
            }
        }
    }



}
