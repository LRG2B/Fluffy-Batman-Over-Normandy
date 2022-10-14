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
        playing = true; // Declare a boolean that loops through our music tracks while true
        musicSource = FindObjectOfType <AudioSource>();
        musicSource.loop = false;
    }

    private AudioClip GetRandomClips()
    {
        return musicClips[Random.Range(0, musicClips.Length)];
    }

    IEnumerator PlayMusicLoop()
    {
        yield return null;
        while (playing)
        {
            musicSource.clip = GetRandomClips();
            musicSource.Play();
        }
    }
}