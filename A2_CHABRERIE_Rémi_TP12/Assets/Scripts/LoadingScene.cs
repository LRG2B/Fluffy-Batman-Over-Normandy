using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    public int ModeChrono;
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
    }

    public void LoadingScene1(string NomScene)
    {
        ModeChrono = 0;
        SceneManager.LoadScene(NomScene);
    }

    //On lance le mode Chrono auquel un bool sera positive
    //Donc vu que ModeChrono sera positif il pourra activer ou désactiver des canvas
    public void LoadingChronoMode()
    {
        ModeChrono += 1;
        LoadingScene1("Game");
    }

    public void ResetScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
