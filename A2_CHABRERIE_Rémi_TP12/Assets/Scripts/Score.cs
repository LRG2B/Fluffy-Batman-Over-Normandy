using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text ContainerScore;
    public Text highscoreContainer;

    private float Score_Z;

    void Start()
    {
        //Valeur par défaut
        //Les données sont stockés dans HighScore
        highscoreContainer.text = PlayerPrefs.GetFloat("HighScore",0).ToString();
        Score_Z = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Score_Z = transform.position.z;
        ContainerScore.text = Score_Z.ToString();
        StockageScore();
    }

    public void StockageScore()
    {
        if (Score_Z > PlayerPrefs.GetFloat("HighScore", 0))
        {
            PlayerPrefs.SetFloat("HighScore", Score_Z);
            highscoreContainer.text = Score_Z.ToString();
        }
    }

    /*
    public void ResetScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
    }*/
}
