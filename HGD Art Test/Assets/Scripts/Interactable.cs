using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public GameObject obj;    // The current position of the object
    public Vector3 pos;    
    public Vector3 offset;

    private double distToPlayer;  // Stores the current distance to the player
    public int status = 0;

    // TEMPORARY
    private DistToNPC gm;

    public bool isMoving;

    private void Awake()
    {
        obj = gameObject;
        pos = transform.position;
        gm = FindObjectOfType<DistToNPC>();
    }

    public void FixedUpdate()
    {
        if (isMoving)
        {
            pos = transform.position;
            gm.CalculateDistance();
        }
    }

    public int getStatus() //Gets status of interactable, 0 if not near, 1 if near, and 2 if prompting the player
    {
        return this.status;
    }

    public void setStatus(int s) //Set status of interactable
    {
        status = s;
    }

    public double getDist() //Returns the distance to the player
    {
        return this.distToPlayer;
    }

    public void setDist(double d) //Sets the distance to the player, "d" = Distance to player
    {
        this.distToPlayer = d;
    }

    public override bool Equals(object other)
    {
        // If other is not of type NPC
        if (!(other is NPC)) { return false; }
        // If other does not have the same name as this NPC
        if (((NPC)other).name != this.name) { return false; }
        return true;
    }
}
