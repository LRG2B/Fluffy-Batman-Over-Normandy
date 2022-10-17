using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicChangeVolume : MonoBehaviour
{

    [SerializeField] Slider volumeSlider;       //Create a slider

    // Start is called before the first frame update
    void Start()
    {
        Load();
    }

    public void ChangeVolume()          
    {
        AudioListener.volume = volumeSlider.value;      //The slider get the volume of the sound and we can changing it 
        Save();                                         //We called this function, for saving the value 
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");       //The slider get the volume of musicVolume
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);           //Update the value of the slider
    }

}
