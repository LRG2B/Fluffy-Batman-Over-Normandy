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
        //Il r�cup�re la donn�e donc 
        ModeChronoIsActive = PlayerPrefs.GetInt("ModeChronoActivation",0);          //We get the value of the playerPrefs for button "Chrono"

        if (ModeChronoIsActive == 5)                            //If this value was 5
        {
            ActiveTimer();                          //We active the GameObejct who contain the script Timer
            //Il d�truit la cl� pour �viter que le mode chrono s'active quand on lance le mode normal (donn�e toujours � 5)
            PlayerPrefs.SetInt("ModeChronoActivation", 0);          //We get the value Zero for not going back to the chronoMode
        }                                                           //If we want to go to infinite mode
    }

    public void ActiveTimer()
    {
        Object_ActiveTimer.SetActive(true);                     //Activate the GameObject
    }
}
