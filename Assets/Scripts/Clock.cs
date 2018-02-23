using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Authored by Miao Ren & Jett Lee
 */ 

public class Clock : MonoBehaviour
{
	public bool isActive; // able to manipulate the clock
	public static int time = 12; // current time hour

    [SerializeField] GameObject player; // the VR content 
    [SerializeField] GameObject clock;

    private float px; // current VR object x
    bool in_range = false; // if player stands in clock interactive area

    //clock
    public GameObject minHand; 
    public GameObject hourHand;


    public GameObject hint; // hint sign on the clock

    public int direction; // 1: future, -1: past

    //private AudioSource finishSceneSpeaker; 

    //steam vr
    private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    //init
    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        //player = GameObject.Find("VR");
        //clock = GameObject.FindGameObjectWithTag("Clock");
        px = player.transform.position.x;
    }

    void Update()
    {
		if (isActive) { 
			if (in_range) {
				if (Controller.GetHairTriggerDown ()) {
					//Debug.Log (gameObject.name + " Trigger Press");
					//Debug.Log ("trigger");
					px = player.transform.position.x;
					if (direction == -1) { // lefthand: go to the past
                        hint.SetActive(false); // ???
						//Debug.Log ("back");
						//Debug.Log (px);
						if (px > 0f && HintManager.status < 3) { //make sure when status == 3 (when player should go to 12 and wait), player can't travel back
                            
							clockSound.playClockRotateSound ();             
							StartCoroutine (backMinRotate ());
							StartCoroutine (backHourRotate ());
							px -= 5f;
							time--;
                            cameraScript.script.saturation = 0.12f;

                            if (time == 11)
                            {
                                playerSound.playHintBGM();
                            }
                            else if (time == 10)
                            {
                                playerSound.playBackBGM();
                            }
                            //Debug.Log (px);
                            clock.transform.parent = player.transform;
                            player.transform.position = new Vector3 (px, 0f, -0.3f);
						}

					} else if (direction == 1) { //future
						//Debug.Log ("forward");
						if (px < 20f) {
							clockSound.playClockRotateSound ();
							StartCoroutine (forMinRotate ());
							StartCoroutine (forHourRotate ());
                            time++;
                            px += 5f;
                            if (time == 11)
                            {
                                playerSound.playHintBGM();
                            }
                            else if (time == 12)
                            {
                                cameraScript.script.saturation = 1.0f;
                                if (HintManager.status != 3)
                                {
                                    playerSound.playMurderBGM();
                                }
                                else if (HintManager.status == 3)
                                {
                                    playerSound.playFinishBGM();
                                }
                            }
            
                            //Debug.Log (px);
                            clock.transform.parent = player.transform;
                            player.transform.position = new Vector3 (px, 0f, -0.3f);
						}

					}

                }
			}
		}

    }

    //range detection
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Clock")
            in_range = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Clock")
            in_range = false;
    }

    //clock hands behaviors
    IEnumerator forMinRotate()
    {
        for (int i = 0; i < 90; i++)
        {
            minHand.transform.Rotate(new Vector3(-4, 0, 0));
            yield return 0;
        }
    }

    IEnumerator forHourRotate()
    {
        for (int i = 0; i < 90; i++)
        {
            hourHand.transform.Rotate(new Vector3(-1 / 3f, 0, 0));
            yield return 0;
        }
    }

    IEnumerator backMinRotate()
    {
        for (int i = 0; i < 90; i++)
        {
            minHand.transform.Rotate(new Vector3(4, 0, 0));
            yield return 0;
        }
    }

    IEnumerator backHourRotate()
    {
        for (int i = 0; i < 90; i++)
        {
            Debug.Log("in coroutine");
            hourHand.transform.Rotate(new Vector3(1 / 3f, 0, 0));
            yield return 0;
        }
    }

}
