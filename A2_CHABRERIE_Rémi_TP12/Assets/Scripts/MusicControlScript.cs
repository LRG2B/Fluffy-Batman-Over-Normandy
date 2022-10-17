using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControlScript : MonoBehaviour
{
    public bool playing; // Declare a boolean that loops through our music tracks while true
    public AudioSource musicSource; //AudioSource
    public AudioClip[] musicClips; //Array qui se stocke tous les sons

    void Start()
    {
        playing = true; // Set our "playing" boolean to true
        StartCoroutine(PlayMusicLoop()); // Start our coroutine that will loop through our music tracks
    }

    private AudioClip GetRandomClips()      
    {
        return musicClips[Random.Range(0, musicClips.Length)];      //This function put a value between 0 and the number of sounds
    }                                                               //After this, he playing the sounds with the number associated (int the tab)

    IEnumerator PlayMusicLoop() // A coroutine allows you to spread tasks across several frames. In Unity, a coroutine is a method that can pause execution and return control to Unity but then continue where it left off on the following frame
    {
        yield return null; // Wait for the next frame and continue execution from this line
        while (playing) // While our "playing" boolean is set to true, our music tracks will continue to loop
        {
            for (int i = 0; i < musicClips.Length; i++) // A for loop where we declare an integer "i" as 0; Continue to for loop while "i" is less than the size of our music clips array; At the end of each loop increase the value of "i" by 1;
            {
                musicSource.clip = GetRandomClips(); // Select the music clip in our music clip array that "i" corresponds to
                musicSource.Play(); // Play our AudioSource

                // P permet de skip les musiques
                while (musicSource.isPlaying)    // While a song is playing
                {
                    yield return null; // Do nothing / wait for end of song
                }
            }
        }
    }
}