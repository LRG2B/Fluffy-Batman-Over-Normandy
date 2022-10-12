using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    [Tooltip("Player gameobject")]
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");                        //Set player as the gameobject of the player
    }

    void Update()
    {
        if (transform.position.z + 40 < player.transform.position.z)                //If the Y position of the crate or the barrier is behind the Y position of the player with an offset of 20
            Destroy(gameObject);                                                    //Destroy the attached object
    }
}
