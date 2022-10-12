using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Player gameobject")]
    private GameObject player;
    [Tooltip("Camera offset")]

    private float AxeY;
    private float AxeZ;
    private Vector3 offset;

    void Start() {
        AxeY = 6.66f;
        AxeZ = -12.97f;
        offset = new Vector3(0, AxeY, AxeZ);
    }

    void LateUpdate() { 
        transform.position = player.transform.position + offset;                                                                            //Set the camera position at the player position + it offset
    }
}