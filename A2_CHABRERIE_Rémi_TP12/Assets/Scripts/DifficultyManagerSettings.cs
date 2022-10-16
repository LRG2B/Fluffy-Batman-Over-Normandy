using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultySettings : MonoBehaviour
{
    //public GameObject Road1;
    //public GameObject Road2;
    public GameObject Car;
    public int AdditionNewMaxSpeed = 10;
    public int AdditionNewMinSpeed = 10;
    public float DistanceActivation = 100f;
    //public float Score_z;
    public int NbreActivation;

    //Distance parcourue
    private float Score_z;

    // Start is called before the first frame update
    void Start()
    {
        Score_z = Car.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        //Quand le véhicule aura atteint x distance, on change les settings
        /*if (Score_z == DistanceActivation)
        {
            PlayerControllerLoic.instance.MaxSpeed += AdditionNewMaxSpeed;
            PlayerControllerLoic.instance.MinSpeed += AdditionNewMinSpeed;
            //Diminution de la route
            Vector3 ltemp = Road1.transform.localScale;
            ltemp.z -= 1;
            Road1.transform.localScale = ltemp;
            Road2.transform.localScale = ltemp;

            DistanceActivation += 100;
        }*/
        Score_z = Car.transform.position.z;

        if (Score_z >= DistanceActivation)
        {
            NbreActivation += 1;
            PlayerControllerLoic.instance.MaxSpeed += AdditionNewMaxSpeed;
            PlayerControllerLoic.instance.MinSpeed += AdditionNewMinSpeed;
            PlayerControllerLoic.instance.Accelaration += 0.001f;

            DistanceActivation += 100;

        }
    }


}
