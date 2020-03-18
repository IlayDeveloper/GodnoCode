using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravitation : MonoBehaviour
{
    [SerializeField] private float g=9.8f;
    private float mass;
    
    // Update is called once per frame
    void Update()
    {
        float shipMass = SpaceShip.Instance.mass;
        //float force =  g * (mass * SpaceShip.Instance.mass)/()
    }

    private void Start()
    {
        mass = GetComponent<Rigidbody>().mass;
    }
}
