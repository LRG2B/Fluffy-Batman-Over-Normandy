using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControllerLoic : MonoBehaviour
{
    public float Speed = 20.0f;
    public float turnSpeed = 45.0f;
    private float horizontalInput;
    private float ForwardInput;

    public float MinSpeed = 20.0f;
    public float MaxSpeed = 100.0f;
    public float Accelaration = 0.005f;

    public static PlayerControllerLoic instance;

    private void Awake()
    {

        if (instance != null && instance != this)
        {
            Debug.LogWarning("PlayerController deja existant ");
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }


    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        ForwardInput = Input.GetAxis("Vertical");
        float position = transform.position.y;

        transform.Translate(Vector3.forward * Time.deltaTime * Speed * ForwardInput);
        if (ForwardInput < 0)
            horizontalInput = -horizontalInput;

        if (ForwardInput != 0)
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);


        //Partie accélérration/décelarration
        if (Input.GetKey("up") && Speed != MaxSpeed)
            Speed += Accelaration;
        else
        {
            Speed -= Accelaration;
            if (Speed < MinSpeed)
                Speed = MinSpeed;
        }

        //Si le véhicule tombe et atteint une certaine distance de chute, il pourra plus bouger
        if (transform.position.y < 0 || transform.position.y > 3)
        {
            Speed = 10;
        }

        //Pour pas qu'il bouge
        float positionFall = transform.position.y;
        if (positionFall < 0 || positionFall > 3.5f)
        {
            //Il peut pas bouger
            horizontalInput = 0;
            ForwardInput = 0;
        }

        if (positionFall < -5f)
            SceneManager.LoadScene("GameLose");
    }

}