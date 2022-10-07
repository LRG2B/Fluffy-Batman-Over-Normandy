using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text ContainerScore;

    private float Score_Z;

    void Start()
    {
        Score_Z = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Score_Z = transform.position.z;
        ContainerScore.text = Score_Z.ToString();
    }
}
