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

    public int effect_time;

    private float Zpos;

    private void Awake()
    {

        Speed += PlayerPrefs.GetFloat("UpgradeSpeed");                      //Speed get the value of the PlayerPrefs UpgradeSpeed

        if (instance != null && instance != this)
        {
            Debug.LogWarning("PlayerController deja existant ");
            Destroy(this);
        }
        else
        {
            instance = this;
        }

        effect_time = 0;
    }


    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");          //We get the Axis Horizontal of the Batmobile
        ForwardInput = Input.GetAxis("Vertical");               //We get the Vertical Horizontal of the Batmobile
        float position = transform.position.y;                  //Position Y is stocked in position

        if (effect_time > 0)
        {
            if (Input.GetKey("up") && Speed != MaxSpeed)       //IF we put the Up Arrow Key and the actual speed of the car isn't the maxSpeed
                Speed = Speed + Accelaration + 0.05f;           //We increase the speed
            effect_time--;
        }
        else
        {
            //Partie accélérration/décelarration
            if (Input.GetKey("up") && Speed != MaxSpeed)
                Speed += Accelaration;
        }
        
        transform.Translate(Vector3.forward * Time.deltaTime * Speed * ForwardInput);       //For moving forward
        if (ForwardInput < 0)                                                               //When we doing backtrack
            horizontalInput = -horizontalInput;

        if (ForwardInput != 0)
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);     //For turning



        if (transform.position.y < 0 || transform.position.y > 3)       //When the car starting falling
        {
            Speed = 10;     //His speed was this value for falling
        }

        //Pour pas qu'il bouge
        float positionFall = transform.position.y;
        if (positionFall < 0 || positionFall > 3.5f)        //When the car starting falling and he gets this value (3.5)
        {
            //Il peut pas bouger
            horizontalInput = 0;        //He can't move forward
            ForwardInput = 0;           //he can't move at all
        }

        if (positionFall < -5f)         //When the car gets this position (after he starting falling)
        {
            Zpos = Mathf.Round(transform.position.z);
            SceneManager.LoadScene("GameLose");             //We launch the scene gameLose
            PlayerPrefs.SetFloat("nbCoins", Zpos / 10);
        }

    }

    public void UpdateSpeed(int time)
    {
        effect_time += time;
    }

    public void UpgradeSpeed()
    {
        Speed += 20;
    }

}