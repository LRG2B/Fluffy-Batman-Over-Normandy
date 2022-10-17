using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [Tooltip("Player gameobject")]
    public GameObject player;

    //FirstCam = (0,1f,3.45f) good
    //ThirdCam = 0, 6.66f, -12.97f good
    public float AxeY = 0.1f;
    public float AxeZ = 3.45f;

    private Vector3 offset;

    void Start()
    {
        offset = new Vector3(0, AxeY, AxeZ);            //We create a new vector
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;     //The camera follow the car with a smoth animation with the LateUpdate                                                                        //Set the camera position at the player position + it offset
    }
}