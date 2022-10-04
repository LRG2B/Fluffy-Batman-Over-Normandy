using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChanges : MonoBehaviour
{
    public GameObject ThirdCam;
    public GameObject FirstCam;
    public int CamMode;

    // Update is called once per frame
    void Update()
    {
        //Quand on appuie sur c on change de cam�ra
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (CamMode == 1)
            {
                CamMode = 0;
            }
            else
            {
                CamMode += 1;
            }
            //On lance une coroutine pour �viter les erreurs
            StartCoroutine (CamChange ());
        }
    }

    IEnumerator CamChange()
    {
        yield return new WaitForSeconds (0.01f);
        //Si CamMode = 0 alors ThirdCam
        if (CamMode == 0)
        {
            //Activer la cam�ra � la troisi�me personne
            ThirdCam.SetActive(true);
            //Et donc on d�sactive la cam�ra premi�re p
            FirstCam.SetActive(false);
        }
        if (CamMode == 1)
        {
            //Inverse de CamMode == 0
            ThirdCam.SetActive(false);
            FirstCam.SetActive(true);
        }
    }

}
