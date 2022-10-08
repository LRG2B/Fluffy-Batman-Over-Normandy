using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class CheckModeChronoisActive : MonoBehaviour
{
    public int ModeChronoIsActive;
    public GameObject Object_ActiveTimer;


    void Update()
    {
        //Il récupère la donnée donc 
        ModeChronoIsActive = PlayerPrefs.GetInt("ModeChronoActivation",0);

        if (ModeChronoIsActive == 5)
        {
            ActiveTimer();
            //Il détruit la clé pour éviter que le mode chrono s'active quand on lance le mode normal (donnée toujours à 5)
            PlayerPrefs.SetInt("ModeChronoActivation", 0);
            //PlayerPrefs.DeleteKey("ModeChronoActivation");
        }
    }

    public void ActiveTimer()
    {
        Object_ActiveTimer.SetActive(true);
    }
}
