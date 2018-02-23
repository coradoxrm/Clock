using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Authored by Jett Lee
 */

public class clockTextureChange : MonoBehaviour {

	public Material texture12;
	public Material texture11;
	public Material texture10;
	public Material texture9;
	public Material texture8;
	private int time;
    private GameObject clockInterface;


	void Start () {
        clockInterface = GameObject.Find("TimeClockInterface");
	}
	
	void Update () {

		time = Clock.time;

		if (time == 12 && ClockKeyhole.isActive) 
		{
            clockInterface.GetComponent<Renderer>().material = texture12;
		} else if (time == 11 && ClockKeyhole.isActive) 
		{
            clockInterface.GetComponent<Renderer>().material = texture11;
        } else if (time == 10 && ClockKeyhole.isActive) 
		{
            clockInterface.GetComponent<Renderer>().material = texture10;
        } else if (time == 9 && ClockKeyhole.isActive)
		{
            clockInterface.GetComponent<Renderer>().material = texture9;
        } else if (time == 8 && ClockKeyhole.isActive)
		{
            clockInterface.GetComponent<Renderer>().material = texture8;
        }
	}
}
