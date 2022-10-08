using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{

    public static LoadingScene instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Debug.LogWarning("Instance LoadingScene deja existant ");
            Destroy(this);
        }
        else
        {
            instance = this;
            //DontDestroyOnLoad(instance);
        }
        //PlayerPrefs.DeleteKey("ModeChronoActivation");
    }

    public void Start()
    {
        //Destruction de la sc�ne pr�c�dente et cr�ation d'une nouvelle
        //PlayerPrefs.DeleteKey("ModeChronoActivation");
        PlayerPrefs.GetInt("ModeChronoActivation", 0);
    }

    //NE PAS Y TOUCHER
    public void LoadingScene1(string NomScene)
    {
        SceneManager.LoadScene(NomScene);
    }
    //On lance le mode Chrono auquel un bool sera positive
    //Donc vu que ModeChrono sera positif il pourra activer ou d�sactiver des canvas
    public void LoadingChronoMode()
    {
        //Si on lance le mode Chrono on passe en param�tre 5
        PlayerPrefs.SetInt("ModeChronoActivation", 5);
        LoadingScene1("Game");
    }

    //Pour d�truire la cl� 
    public void ResetScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
    }

    //Pour quitter le jeu -> NE PAS Y TOUCHER
    public void QuitGame()
    {
        Application.Quit();
    }
}
