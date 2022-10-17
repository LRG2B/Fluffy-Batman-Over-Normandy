using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [Tooltip("Text container for the score")]
    public Text ContainerScore;
    [Tooltip("Text container for the highest score")]
    public Text highscoreContainer;

    [Tooltip("")]
    private int ModeContainerChrono;

    [Tooltip("")]
    private float Score_Z;

    void Start()
    {
        highscoreContainer.text = PlayerPrefs.GetFloat("HighScore",0).ToString();               //Set the text of the score container as the highest score saved in the playerprefs
        //Rajout
        //ContainerScore.text = PlayerPrefs.GetFloat("CurrentScore", 0).ToString();

        Score_Z = transform.position.z;
        ModeContainerChrono = PlayerPrefs.GetInt("ModeChronoActivation", 0);
    }

    // Update is called once per frame
    void Update()
    {
        Score_Z = transform.position.z;                     //Score_z is the z position of the score, we use it for get the actual score of the player
        ContainerScore.text = Score_Z.ToString();           //We put this Score_z into a container text for showing to the player his score

        //Rajout
        PlayerPrefs.SetFloat("CurrentScore", Score_Z);      //We put his actual score into a playerPrefs CurrentScore

        StockageScore();                                    
    }

    public void StockageScore()
    {
        //Si le score actuel est plus élévé que le highscore on enregistre le score
        if (Score_Z > PlayerPrefs.GetFloat("HighScore", 0) && ModeContainerChrono == 5)     //If the actual Score of the player is higher than the HighScore (0 in the beginning at all)
        {                                                                                   //And the ModeChrono are active with the recuperation of the playerPrefs (view in another Script). 
            highscoreContainer.text = Score_Z.ToString();                   //So the highscore can be storage only if the player are in chrono mode
            PlayerPrefs.SetFloat("HighScore", Score_Z);                     //We update the HighScore with the new dataand we show it to the player
        }
    }
}
