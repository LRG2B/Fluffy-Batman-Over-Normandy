using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effects : MonoBehaviour
{
    private GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerControllerLoic>().UpdateSpeed(50);
        Destroy(gameObject);
    }
}
