using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManagerSettings : MonoBehaviour
{
    public GameObject Road1;
    public GameObject Road2;
    public GameObject Car;
    public float AdditionNewMaxSpeed = 5;
    public float AdditionNewMinSpeed = 5;
    public float AdditionNewAcceleration = 0.001f;
    public float DistanceActivation = 200f;
    public float AdditionNewDistanceActivation = 100f;

    //Distance parcourue
    private float Score_z;
    private Vector3 vRoad1;
    private Vector3 vRoad2;

    // Start is called before the first frame update
    void Start()
    {
        Score_z = Car.transform.position.z;

    }

    // Update is called once per frame
    void Update()
    {
        vRoad1 = Road1.transform.position;
        vRoad2 = Road2.transform.position;

        vRoad1.x -= 1;
        vRoad2.x -= 1;
        Score_z = Car.transform.position.z;

        if (Score_z >= DistanceActivation)
        {
            /*vRoad1.x -= 1;
            vRoad2.x -= 1;
            Road1.transform.localScale = vRoad1;
            Road2.transform.localScale = vRoad2;*/

            PlayerControllerLoic.instance.MaxSpeed += AdditionNewMaxSpeed;
            PlayerControllerLoic.instance.MinSpeed += AdditionNewMinSpeed;
            PlayerControllerLoic.instance.Accelaration += AdditionNewAcceleration;

            DistanceActivation += 100;
        }
    }


}
