using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChanges : MonoBehaviour
{
    [Tooltip("Gameobject of the third person camera")]
    public GameObject ThirdCam;
    [Tooltip("Gameobject of the first person camera")]
    public GameObject FirstCam;
    [Tooltip("Active value of the camera mode (First person or Third person, 0 or 1)")]
    public int CamMode;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))                                //If the user press C
        {
            if (CamMode == 1)                                           //If the cammode value = 1
                CamMode = 0;                                            //Set camMode to 0
            else                                                        //Else, if the camMode value = 0
                CamMode = 1;                                            //Set camMode to 1
            StartCoroutine (CamChange ());                              //Start the coroutine to change the camera mode
        }
    }

    IEnumerator CamChange()
    {
        yield return new WaitForSeconds (0.01f);                        //Wait 0.01 seconds
        if (CamMode == 0)                                               
        {
            ThirdCam.SetActive(true);                                   //Activate the third camera
            FirstCam.SetActive(false);                                  //Desactivate the first camera
        }
        if (CamMode == 1)
        {
            //Inverse de CamMode == 0
            ThirdCam.SetActive(false);                                  //Desactivate the third camera
            FirstCam.SetActive(true);                                   //Activate the first camera
        }
    }
}