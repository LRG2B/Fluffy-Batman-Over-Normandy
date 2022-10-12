using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateStaticRoad : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Gamobject of the road prefab that will be instantiate")]
    private GameObject road_pattern;

    [SerializeField]
    [Tooltip("Gameobject of the sidewalk")]
    private GameObject sidewalk;

    [SerializeField]
    [Tooltip("Gameobject of the player")]
    private GameObject player;

    [SerializeField]
    [Tooltip("Gameobject of the crate that will be instantiate")]
    private GameObject crate;

    [Tooltip("Position of the instantiated road")]
    private Vector3 pos;

    [Tooltip("Position of the instantiated crate")]
    private Vector3 pos_obstacle;

    [Tooltip("Position of the instantiated sidewalk")]
    private Vector3 pos_sidewalk;

    [Tooltip("Size of the road")]
    private float road_size = 0;

    [Tooltip("Number of road that have been instantiate since the beginning")]
    private int nb_road = 1;

    [Tooltip("Distance covered by road")]
    private int distance;

    [Tooltip("Z position of the player")]
    private float player_posZ;

    [SerializeField]
    [Tooltip("Array of obstacles gameobject")]
    private GameObject[] obstacles;

    [Tooltip("Random id of the array of obstacles")]
    private int i;

    [Tooltip("Y position of the instantiated obstacles")]
    private float yPos_obstacle;

    void Start()
    {
        pos = new Vector3(0, 0, nb_road * 20);                                                                  //Set the position of the first instantiated road, Z being the number of instantiated road time the size of a road
        GameObject.Instantiate(road_pattern, pos, Quaternion.identity);                                         //Instantiate the first road with the road pattern, the former position and a 90° rotation
        nb_road++;                                                                                              //Update the total number of road
        road_size = (road_pattern.GetComponent<Renderer>().bounds.size.x) / 2;                                          //Set the size of the road as the bound size of the road component

        //Debug.Log("Taille de la route : " + road_size);
    }

    void Update()
    {
        player_posZ = Mathf.Round(player.transform.position.z * 10.0f) * 0.1f;                                  //Set the Z player position as a rounded value of it position

        if (distance - player_posZ <= 300)                                                                      //If the distance between the player and the furthest road is less or equal than 300 
        {
            pos = new Vector3(0, 0, nb_road * 20);                                                              //Set a new position for the next road
            GameObject.Instantiate(road_pattern, pos, Quaternion.identity);                                     //Instantiate this road
            distance += 20;                                                                                     //Update the distance reach with road
            i = Random.Range(0, obstacles.Length);                                                              //Get a random id from the obstacles array
            if (i == 4)                                                                                         //If the selected obstacle is the rock
                yPos_obstacle = 1.332553f;                                                                      //Set the Y position so it can spawn
            else                                                                                                //Else
                yPos_obstacle = 0f;                                                                             //Set the normal spawn position
            pos_obstacle = new Vector3(Mathf.Round(Random.Range(-road_size, road_size) * 10.0f) * 0.1f,         //Set the position of the obstacle with X between the X size of the road,
                yPos_obstacle,                                                                                  //Y depending on the obstacle (rock or not),
                Mathf.Round(Random.Range(distance - 10, distance) * 10.0f) * 0.1f);                             //and Z between the Z size of the instantiated road
            GameObject.Instantiate(obstacles[i], pos_obstacle, Quaternion.identity);                            //Instantiate the obstacle

            GameObject.Instantiate(sidewalk, new Vector3(-13, 0, nb_road * 20 - 10), Quaternion.Euler(0, 90, 0));
            GameObject.Instantiate(sidewalk, new Vector3(13, 0, nb_road * 20 - 10), Quaternion.Euler(0, 90, 0));
            nb_road++;                                                                                          //Update the number of road
        }

        Debug.Log("Position du joueur : " + player_posZ + " / Distance de route : " + distance);

        if (distance%1000 == 0)                                                                                 //If the remainder of the division of the distance by 1000 equal 0
        {
            player.GetComponent<PlayerController>().SetSpeed(5);                                                //Enhance the speed of the player
        }
    }
}