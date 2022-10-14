using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text ContainerScore;
    public Text highscoreContainer;

    private int ModeContainerChrono;

    private float Score_Z;

    void Start()
    {
        //Valeur par défaut
        //Rajout

        //Les données sont stockés dans HighScore
        highscoreContainer.text = PlayerPrefs.GetFloat("HighScore",0).ToString();
        //Rajout
        ContainerScore.text = PlayerPrefs.GetFloat("CurrentScore", 0).ToString();

        Score_Z = transform.position.z;
        ModeContainerChrono = PlayerPrefs.GetInt("ModeChronoActivation", 0);
    }

    // Update is called once per frame
    void Update()
    {
        Score_Z = transform.position.z;
        //ContainerScore.text = Score_Z.ToString();

        //Rajout
        PlayerPrefs.SetFloat("CurrentScore", Score_Z);
        ContainerScore.text = PlayerPrefs.GetFloat("CurrentScore", 0).ToString();

        StockageScore();
    }

    public void StockageScore()
    {
        //Si le score actuel est plus élévé que le highscore on enregistre le score
        if (Score_Z > PlayerPrefs.GetFloat("HighScore", 0) && ModeContainerChrono == 5)
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
