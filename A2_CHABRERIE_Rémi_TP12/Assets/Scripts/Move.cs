using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Road gameobject")]
    private GameObject road;
    [Tooltip("Size of the road")]
    private float road_size = 0;
    [Tooltip("Random position")]
    private Vector3 pos;
    [Tooltip("Speed of the crate")]
    private float speed = 8f;
    [Tooltip("X position of the crate at any moment")]
    private float posX = 0f;
    [Tooltip("Y position of the crate at any moment")]
    private float posY = 0f;
    [Tooltip("Y position of the crate at the beginning")]
    private float Original_posY = 0f;
    [Tooltip("Random X coordinate")]
    private float random;
    [Tooltip("Can the crate move ?")]
    private bool can_move;

    void Start()
    {
        can_move = true;                                                                    //Yes
        posY = Mathf.Round(transform.position.y * 10.0f) * 0.1f;                            //Set the original Y coordinate of the crate
        road_size = (road.GetComponent<Renderer>().bounds.size.x) / 2;                      //Take the size of the road, divided by 2 for each side
        random = Mathf.Round(Random.Range(-road_size, road_size) * 10.0f) * 0.1f;           //Take a random value between each side of the road
        pos = new Vector3(random, 0, 0);                                                    //Create a new position with this random value
    }

    void Update()
    {
        posX = Mathf.Round(transform.position.x * 10.0f) * 0.1f;                            //Truncate the x position of the crate
        posY = Mathf.Round(transform.position.y * 10.0f) * 0.1f;                            //Truncate the y position of the crate

        if (can_move)                                                                       //If the crate can move
        {
            if (posX > pos.x)                                                               //If the X position of the crate is upper than the x random position
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed);                 //Translate the crate in the direction of the random position
            }
            else if (posX < pos.x)                                                          //Else if the x position of the crate is lower than the x random position
            {
                transform.Translate(Vector3.right * Time.deltaTime * speed);                //Translate the crate in the direction of the random position
            }
            else                                                                            //Else, if the x positon of the crate equal the x random position
            {
                random = Mathf.Round(Random.Range(-road_size, road_size) * 10.0f) * 0.1f;   //Take another random value between each side of the road
                pos = new Vector3(random, 0, 0);                                            //Create a new random position with this value
            }
        }

        if (posY != Original_posY)                                                          //If the Y position of the crate is different from the start
        {
            can_move = false;                                                               //The crate stop moving
        }

        if (transform.position.y < -5f)                                                     //If the Y position of the crate is beneath -5
        {
            Destroy(this.gameObject);                                                       //Destroy the crate
        }
    }
}