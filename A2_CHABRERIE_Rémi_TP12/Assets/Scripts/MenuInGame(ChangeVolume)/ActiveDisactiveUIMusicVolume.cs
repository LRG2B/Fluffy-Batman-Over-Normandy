using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveDisactiveUIMusicVolume : MonoBehaviour
{

    [SerializeField] GameObject ObjectContainerMenuSound;

    // Start is called before the first frame update
    void Start()
    {
        ObjectContainerMenuSound.SetActive(false);          //By default the gameobject who contain a certain part of the canvas
    }                                                          //Are desactivated

    // Update is called once per frame
    //M for menu
    void Update()
    {
        //Si on appuie sur M on active le canvas
        if (Input.GetKeyDown(KeyCode.M))            //If we put the M button we show the Canvas for the Menu in-game
            ObjectContainerMenuSound.SetActive(true);
    }

    //Générer par un bouton -> Quand on appuie dessus on quitte
    //le menu et on retourne dans le jeu
    public void GoBackToGame()
    {
        ObjectContainerMenuSound.SetActive(false);      //Just a button for close this canvas and go back properly in the game
    }
}
