using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://github.com/SebLague/Spherical-Gravity
public class WorldGravity : MonoBehaviour
{
    public static float gravity = -10f;

    // object to face the world
    public void Attract(Rigidbody body) {
        Vector3 gravityUp = (body.position - transform.position).normalized;
        Vector3 localUp = body.transform.up;

        // Apply gravity to the oject
        body.AddForce(gravity * gravityUp);
        // Align the object y-axis to face the centre of the planet
        body.rotation = Quaternion.FromToRotation(localUp, gravityUp) * body.rotation;
    }

}
