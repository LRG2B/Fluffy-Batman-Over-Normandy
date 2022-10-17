using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{

    public static LoadingScene instance;

    private void Awake()                //Creation instance for using this LoadingScene's function in another script
    {
        if (instance != null && instance != this)
        {
            Debug.LogWarning("Instance LoadingScene deja existant ");
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public void Start()
    {
        PlayerPrefs.GetInt("ModeChronoActivation", 0);          //Create PlayerPrefs for know if the ChronoMode are activate or not
    }                                                           //If it was activate, we put a predifined number in this PlayerPrefs

    //NE PAS Y TOUCHER
    public void LoadingScene1(string NomScene)                  //basic function for loading in scene with his name or his number in the hierarchy
    {
        SceneManager.LoadScene(NomScene);
    }

    //On lance le mode Chrono auquel un bool sera positive
    //Donc vu que ModeChrono sera positif il pourra activer ou désactiver des canvas
    public void LoadingChronoMode()                                 //Function we put in the Launch "Chrono" in "MenuChoixModeJeu" 
    {
        PlayerPrefs.SetInt("ModeChronoActivation", 5);              //Put number 5 in the PlayerPrefs ModeChronoActivation , we using this number in another script
        LoadingScene1("Game");                                      //For setactive a object who contain the script Score
                                                                    //Launch the functon LoadingScene1
    }

    public void ResetScore()
    {
        PlayerPrefs.DeleteKey("HighScore");                     //Destroy the key who contain HighScore for reset
    }

    public void QuitGame()
    {
        Application.Quit();                                     //Quit the Application, this function was using with a button
    }
}
