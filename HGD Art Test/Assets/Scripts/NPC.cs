using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// NPC Object, allows the DistToNPC and any other classes to discover this NPC object. Additionally, stores the npc gameobject and position for easy access.
/// </summary>
public class NPC : MonoBehaviour
{
    public GameObject npc;
    public Vector3 pos;
    public float distToPlayer;

    //TODO: Currently causes issues with gizmos (and other functions) when the NPC itself is moved. Could benefit from an update function, but I'm curious about a more performance alternative.
    private void Awake()
    {
        npc = gameObject;
        pos = transform.position;
    }

    public void setDist(float d)
    {
        distToPlayer = d;
    }

    /// <summary>
    /// Overriden ToString to grab the objects name and position.
    /// </summary>
    /// <returns>Name and position</returns>
    public override string ToString() { 
        return "Name: " + npc.name + "\nPosition: " + pos; 
    }
}
