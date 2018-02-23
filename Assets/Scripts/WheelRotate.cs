using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotate : MonoBehaviour {


    public Wheel w1;
    public Wheel w2;
    public Wheel w3;


    private SteamVR_TrackedObject trackedObj;

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
       
    }
	
	//// Update is called once per frame
	void Update () {

        //transform.rotation = Quaternion.Lerp(transform.rotation, to.rotation, Time.time * speed);

    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name == "wheel1" && Controller.GetHairTriggerDown())
        {
            w1.StartRotate();
        }
        if (other.gameObject.name == "wheel2" && Controller.GetHairTriggerDown())
        {
            w2.StartRotate();
        }
        if (other.gameObject.name == "wheel3" && Controller.GetHairTriggerDown())
        {
            w3.StartRotate();
        }
    }


}
