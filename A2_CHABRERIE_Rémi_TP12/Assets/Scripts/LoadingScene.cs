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
    }

    public void LoadingScene1(string NomScene)
    {
        SceneManager.LoadScene(NomScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
