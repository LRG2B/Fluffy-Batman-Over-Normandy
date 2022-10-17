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
    public float AdditionNewDistanceActivation = 200f;

    //Distance parcourue
    private float Score_z;          //Storage the position z of the car
    private Vector3 vRoad1;         //Get Vector3 for resize the RoadPattern to getting better difficulty
    private Vector3 vRoad2;         //Get the second Vector3 for the second RoadPattern GameObject

    // Start is called before the first frame update
    void Start()
    {
        Score_z = Car.transform.position.z;             //Score_z get the z position of the Batmobile

    }

    // Update is called once per frame
    void Update()
    {
        vRoad1 = Road1.transform.position;          //Get RoadPattern GameObject for resize for getting better difficulty
        vRoad2 = Road2.transform.position;          //Get the second RoadPattern GameObject

        vRoad1.x -= 1;                              //Decrease the x size of the vector and after the RoadPattern
        vRoad2.x -= 1;                              //Same but with the second object
        Score_z = Car.transform.position.z;         //Update the Score_z, we know the distance the car traveed

        if (Score_z >= DistanceActivation)          //If the car has traveled enough distance
        {


            PlayerControllerLoic.instance.MaxSpeed += AdditionNewMaxSpeed;          //We upgrade the MaxSpeed of the car
            PlayerControllerLoic.instance.MinSpeed += AdditionNewMinSpeed;          //We upgrade the MinSpeed of the car
            PlayerControllerLoic.instance.Accelaration += AdditionNewAcceleration;             //And the acceleration

            DistanceActivation += AdditionNewDistanceActivation;      //We put a new DistanceActivation for the next if condition
        }
    }


}
