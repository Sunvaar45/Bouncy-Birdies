using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScript : MonoBehaviour
{
    public BirdScript bird;
    public ParticleSystem clouds;
    public float slowerCloudSpeed = .3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bird.birdIsAlive == false)
        {
            slowCloud();
        }
    }

    public void slowCloud()
    {
        var main = clouds.main;
        main.simulationSpeed = slowerCloudSpeed;
    }
}
