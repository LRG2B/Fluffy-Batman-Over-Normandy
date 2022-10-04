using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController_Physique1_3 : MonoBehaviour
{
    [Tooltip("Maximum speed of the player")]
    private float max_speed = 2f;
    [Tooltip("Minimum speed of the player")]
    private float min_speed = 1f;
    [Tooltip("Turn speed of the player")]
    private Vector3 turnspeed;
    [Tooltip("Delta for the turnspeed of the player")]
    private Quaternion delta;
    [Tooltip("Inputs of the player in a Vector3")]
    private Vector3 Inputs;
    [Tooltip("RigidBody of the player")]
    private Rigidbody RB_player;
    [SerializeField]
    [Tooltip("Gameobject to determine whether the car is grounded or not")]
    private GameObject GroundCheck;

    void Start()
    {
        RB_player = this.GetComponent<Rigidbody>();                                                 //Set the rigidbody gameobject as the rigidbody of the player
        turnspeed = new Vector3(0, 100, 0);                                                         //Set the turnspeed of the player as a Vector3 with a Y value
    }

    void Update()
    {
        Inputs = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));            //Set the inputs of the player as a Vector3
    }

    private void FixedUpdate()
    {
        if (RB_player.transform.position.y < 0.1f || RB_player.transform.position.y > -0.1f)              //If the Y position of the player is between 1 and -1
        {
            delta = Quaternion.Euler(turnspeed * Time.fixedDeltaTime * Inputs.x);                   //Set the delta for the turnspeed
            RB_player.MovePosition(transform.position + Inputs + Vector3.forward * max_speed);      //Set the new position of the player
            RB_player.MoveRotation(transform.rotation * delta);                                     //Set the new rotation of the player

            //if (Inputs.x == 0)                                                                      //If the player don't want to rotate
            //{
            //    if (RB_player.transform.rotation.y < 0)                                             //If the rotation of the RB of the player is lower than 0
            //    {
            //        delta = Quaternion.Euler(turnspeed * Time.fixedDeltaTime * 1);                  //Set a delta in the other direction
            //        RB_player.MoveRotation(transform.rotation * delta);                             //Rotate the RB of the player in this direction
            //    }
            //    else if (RB_player.transform.rotation.y > 0)                                        //If the rotation of the RB of the player is greater than 0
            //    {
            //        delta = Quaternion.Euler(turnspeed * Time.fixedDeltaTime * -1);                 //Set a delta in the other direction
            //        RB_player.MoveRotation(transform.rotation * delta);                             //Rotate the RB of the player to this direction
            //    }
            //}

            if (Inputs.x < 1)                                                                       //If the player forward input is lower than 1
                RB_player.MovePosition(transform.position + Inputs + Vector3.forward * min_speed);  //Translate the player with the minimum speed
        }

        if (RB_player.transform.position.y < -5f)                                                   //If the Y position of the player RB is beneath -5
        {
            SceneManager.LoadScene("GameLose");                                                     //Load the lose scene
        }
    }
}