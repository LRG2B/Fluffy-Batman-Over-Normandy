using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    void Start()
    {
        if (SceneManager.GetActiveScene().name != "Game")                           //If the active scene isn't the game scene
            StartCoroutine(ChangeScene());                                          //Start the corountine
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(3);                                         //Wait 3 seconds
        SceneManager.LoadScene("MainMenu");                                         //Load the main menu
    }
}