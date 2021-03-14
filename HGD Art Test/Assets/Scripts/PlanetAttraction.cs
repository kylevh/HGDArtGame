using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://github.com/SebLague/Spherical-Gravity

public class PlanetAttraction : MonoBehaviour
{
    WorldGravity planet;
    Rigidbody rigidbody;

    void Awake()
    {
        planet = GameObject.FindGameObjectWithTag("Planet").GetComponent<WorldGravity>();
        rigidbody = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        planet.Attract(rigidbody);
    }
}
