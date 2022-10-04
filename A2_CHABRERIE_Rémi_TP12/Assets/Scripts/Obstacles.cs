using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    void Update()
    {
        if (transform.position.y < -3f)                                     //If the Y position of the crate is beneath -3
        {
            Destroy(this.gameObject);                                       //Destroy the obstacles
        }
    }
}
