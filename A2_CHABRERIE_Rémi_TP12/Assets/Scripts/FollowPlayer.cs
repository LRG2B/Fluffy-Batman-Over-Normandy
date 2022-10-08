using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [Tooltip("Player gameobject")]
    public GameObject player;
    [Tooltip("Skydome gameobject")]
    //public GameObject skydome;
    //[Tooltip("Mountain sprite gameobject")]
    //public GameObject mountain;
    //[Tooltip("Camera offset")]

    //FirstCam = (0,1f,3.45f) good
    //ThirdCam = 0, 6.66f, -12.97f good
    public float AxeY = 6.66f;
    public float AxeZ = -12.97f;

    private Vector3 offset;
    [Tooltip("Skydome offset")]
    private Vector3 offset_skydome;
    [Tooltip("Mountain sprite offset")]
    private Vector3 offset_mountain;

    void Start() {
        offset = new Vector3(0, AxeY, AxeZ);
        //offset_skydome = new Vector3(skydome.transform.position.x, skydome.transform.position.y, skydome.transform.position.z);             //Set the offset of the skydome as it start position
        //offset_mountain = new Vector3(mountain.transform.position.x, mountain.transform.position.y, mountain.transform.position.z);         //Set the offest of the mountain sprite as it start position
    }

    void LateUpdate() { 
        transform.position = player.transform.position + offset;                                                                            //Set the camera position at the player position + it offset
        //skydome.transform.position = player.transform.position + offset_skydome;                                                            //Set the skydome position at the player position + it offset
        //mountain.transform.position = player.transform.position + offset_mountain;                                                          //Set the mountain position at the player position + it offset
    }
}