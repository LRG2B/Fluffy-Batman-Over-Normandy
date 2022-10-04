using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Tooltip("Minimum speed of the player")]
    private float min_speed = 40;
    [Tooltip("Maximum speed of the player")]
    private float max_speed = 60;
    [Tooltip("Turn speed of the player")]
    private float turnSpeed = 45;
    [Tooltip("Horizontal input of the player")]
    private float horizontalInput;
    [Tooltip("Forward input of the player")]
    private float forwardInput;

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");                                              //Get the horizontal input
        forwardInput = Input.GetAxis("Vertical");                                                   //Get the vertical input

        if (forwardInput < 0)                                                                       //If the verticale input is lower than 0
            transform.Rotate(Vector3.up, turnSpeed * -horizontalInput * Time.deltaTime);            //Rotate the player
        else
            transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);             //Rotate the player

        transform.Translate(Vector3.forward * Time.deltaTime * max_speed * forwardInput);           //Translate the player forward

        if (forwardInput < 1)                                                                       //If the player forward input is lower than 1
            transform.Translate(Vector3.forward * Time.deltaTime * min_speed);                      //Translate the player with the minimum speed

        if (transform.position.y < -5f)                                                             //If the Y position of the player is lower than -5
        {
            SceneManager.LoadScene("GameLose");                                                     //Load the lose scene
        }
    }

    public void SetSpeed(float multiplier)
    {
        max_speed += multiplier;                                                                    //Set a new maximum speed
        min_speed += multiplier;                                                                    //Set a new minimum speed
    }
}