using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{
    public float TimeLeft = 30.0f;
    public Text TempsRestant;
    private string GameLose = "GameLose";
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        //Il doit attendre 3 secondes sur le menu "YOU LOSE" ensuite il relance le level0
        TimeLeft -= Time.deltaTime;
        TempsRestant.text = TimeLeft.ToString();

        if (TimeLeft < 0)
        {
            LoadingScene.instance.LoadingScene1(GameLose); 
        }
    }
}
