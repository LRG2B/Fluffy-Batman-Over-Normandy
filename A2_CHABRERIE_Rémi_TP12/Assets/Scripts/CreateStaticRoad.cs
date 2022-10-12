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
    [Tooltip("Gameobject of the sidewalk prefab that will be instantiate")]
    private GameObject sidewalk_pattern;

    [SerializeField]
    [Tooltip("Gameobject of the wall prefab that will be instiantiate")]
    private GameObject wall_pattern;

    [SerializeField]
    [Tooltip("Gameobject of the player")]
    private GameObject player;

    [SerializeField]
    [Tooltip("Array of obstacles gameobject")]
    private GameObject[] obstacles;

    [Tooltip("Position of the instantiated road")]
    private Vector3 pos;

    [Tooltip("Position of the instantiated left sidewalk")]
    private Vector3 pos_sidewalk_L;

    [Tooltip("Position of the instantiated right sidewalk")]
    private Vector3 pos_sidewalk_R;

    [Tooltip("Position of the left wall")]
    private Vector3 pos_wall_L;

    [Tooltip("Position of the right wall")]
    private Vector3 pos_wall_R;

    [Tooltip("Position of the instantiated crate")]
    private Vector3 pos_obstacle;

    [Tooltip("Size of the road")]
    private float road_size;

    [Tooltip("Number of road that have been instantiate since the beginning")]
    private int nb_road;

    [Tooltip("Distance covered by road")]
    private int distance;

    [Tooltip("Z position of the player")]
    private float player_posZ;

    [Tooltip("Random id of the array of obstacles")]
    private int i;

    void Start()
    {
        nb_road = 1;
        pos = new Vector3(0, 0, nb_road * 20);                                                              //Set the position of the first instantiated road, Z being the number of instantiated road time the size of a road
        GameObject.Instantiate(road_pattern, pos, Quaternion.identity);                                     //Instantiate the first road with the road pattern, the former position and a 90° rotation
        InstantiateSidewalk();                                                                              //Instantiation of the sidewalks
        InstantiateWall();                                                                                  //Instantiation of the walls
        nb_road ++;                                                                                         //Update the total number of road
        road_size = (road_pattern.GetComponent<Renderer>().bounds.size.x) / 2;                              //Set the size of the road as the bound size of the road component
    }

    void Update()
    {
        player_posZ = Mathf.Round(player.transform.position.z * 10.0f) * 0.1f;                              //Set the Z player position as a rounded value of it position

        if (distance - player_posZ <= 1000)                                                                 //If the distance between the player and the furthest road is less or equal than 300 
        {
            pos = new Vector3(0, 0, nb_road * 20);                                                          //Set a new position for the next road
            GameObject.Instantiate(road_pattern, pos, Quaternion.identity);                                 //Instantiate this road
            distance += 20;                                                                                 //Update the distance reach with road
            pos_obstacle = new Vector3(Mathf.Round(Random.Range(-road_size, road_size) * 10.0f) * 0.1f,
                0, 
                Mathf.Round(Random.Range(distance - 10, distance) * 10.0f) * 0.1f);                         //Set the position of the obstacle with X between the X size of the road and Z between the Z size of the instantiated road
            i = Random.Range(0, obstacles.Length);                                                          //Get a random id from the obstacles array
            GameObject.Instantiate(obstacles[i], pos_obstacle, Quaternion.identity);                        //Instantiate the obstacle
            InstantiateSidewalk();                                                                          //Instantiation of the sidewalk
            InstantiateWall();                                                                              //Instantiation of the walls
            nb_road++;                                                                                      //Update the number of road
        }
    }

    private void InstantiateSidewalk()
    {
        pos_sidewalk_R = new Vector3(13, 0, nb_road * 20 - 10);                                             //Set the position for the right sidewalk
        pos_sidewalk_L = new Vector3(-13, 0, nb_road * 20 - 10);                                            //Set the position for the left sidewalk
        GameObject.Instantiate(sidewalk_pattern, pos_sidewalk_R, Quaternion.Euler(0, 90, 0));               //Instantiate the right sidewalk
        GameObject.Instantiate(sidewalk_pattern, pos_sidewalk_L, Quaternion.Euler(0, 90, 0));               //Instantiate the left sidewalk
    }

    private void InstantiateWall()
    {
        pos_wall_L = new Vector3(-15.5f, 9, nb_road * 20 - 10);                                             //Set the position for the left wall
        pos_wall_R = new Vector3(15.5f, 9, nb_road * 20 - 10);                                              //Set the position for the right wall
        GameObject.Instantiate(wall_pattern, pos_wall_L, Quaternion.identity);                              //Instantiate the left wall
        GameObject.Instantiate(wall_pattern, pos_wall_R, Quaternion.identity);                              //Instantiate the right wall
    }
}