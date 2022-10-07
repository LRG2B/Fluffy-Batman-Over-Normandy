using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckModeChronoisActive : MonoBehaviour
{
    public GameObject TextContainer;
    public int RecupBool;

    void Start()
    {
        RecupBool = LoadingScene.instance.ModeChrono;
    }

    void Update()
    {
        RecupBool = LoadingScene.instance.ModeChrono;
        if (RecupBool == 0)
        {
            TextContainer.gameObject.SetActive(true);
        }
        if (RecupBool != 1)
        {
            TextContainer.gameObject.SetActive(false);
        }
    }
}
