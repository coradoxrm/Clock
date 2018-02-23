using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Authored by Miao Ren
 */

public class FileManager : MonoBehaviour {

    //9 am
    public GameObject importantfile;
    public GameObject theory;
    public GameObject backup;
    public GameObject proto1;
    public GameObject proto2;

    //11 am
    public GameObject importantfile_2;
    public GameObject theory_2;
    public GameObject backup_2;
    public GameObject proto1_2;
    public GameObject proto2_2;

    //check list
    public GameObject importantfile_check;
    public GameObject theory_check;
    public GameObject backup_check;
    public GameObject proto1_check;
    public GameObject proto2_check;

    public HintManager hint;

    void Update()
    {

        if (importantfile.activeSelf && backup.activeSelf && theory.activeSelf && proto2.activeSelf && proto1.activeSelf)
        {
            hint.file_done = true;
        }
    }

    //private void OnTriggerEnter(Collider other)
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "importantFile" && other.transform.parent == null)
        {
            other.gameObject.SetActive(false);
            importantfile.SetActive(true);
            importantfile_check.SetActive(true);
            importantfile_2.SetActive(true);
        }

        if (other.gameObject.name == "backUp" && other.transform.parent == null)
        {
            other.gameObject.SetActive(false);
            backup.SetActive(true);
            backup_check.SetActive(true);
            backup_2.SetActive(true);

        }
        if (other.gameObject.name == "theoryOfTime" && other.transform.parent == null)
        {
            other.gameObject.SetActive(false);
            theory.SetActive(true);
            theory_check.SetActive(true);
            theory_2.SetActive(true);
        }
        if (other.gameObject.name == "prototype002" && other.transform.parent == null)
        {
            other.gameObject.SetActive(false);
            proto2.SetActive(true);
            proto2_check.SetActive(true);
            proto2_2.SetActive(true);
        }
        if (other.gameObject.name == "prototype001" && other.transform.parent == null)
        {
            other.gameObject.SetActive(false);
            proto1.SetActive(true);
            proto1_check.SetActive(true);
            proto1_2.SetActive(true);
        }


    }
}
