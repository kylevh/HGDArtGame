using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// <list type="table">
///     <item>Author:
///         <description>Vincent Allen</description>
///     </item>
///     <item>
///         <description>NPC Object, allows the DistToNPC and any other classes to discover this NPC object.</description>
///     </item>
///     <item>
///         <description>Additionally, stores the npc gameobject and position for easy access.</description>
///     </item>
/// </list>
/// </summary>
public class NPC : MonoBehaviour
{
    public GameObject npc;
    // The current position of the NPC
    public Vector3 pos;
    public Vector3 offset;

    // TEMPORARY
    private DistToNPC gm;

    // Stores the current distance to the player
    private double distToPlayer;
    public int status = 0;

    private void Awake()
    {
        npc = gameObject;
        pos = transform.position;

        // TEMPORARY
        gm = FindObjectOfType<DistToNPC>();
    }

    /// <summary>
    /// Returns the status of the NPC
    /// </summary>
    /// <returns>0 if not near, 1 if near, and 2 if prompting the player</returns>
    public int getStatus()
    {
        return this.status;
    }

    /// <summary>
    /// Set status of NPC.   
    /// 0 for not near, 1 for near, and 2 for prompting
    /// </summary>
    /// <param name="s">0 for not near, 1 for near, and 2 for prompting</param>
    public void setStatus(int s)
    {
        status = s;
    }

    /// <summary>
    /// Returns the distance to the player
    /// </summary>
    /// <returns>Distance to player</returns>
    public double getDist()
    {
        return this.distToPlayer;
    }
    /// <summary>
    /// Sets the distance to the player
    /// </summary>
    /// <param name="d">Distance to player</param>
    public void setDist(double d)
    {
        this.distToPlayer = d;
    }

    // TEMPORARY, REMOVE/REPLACE THIS DEPENDING ON IF THE NPC'S WILL BE MOVING OR NOT
    private void Update()
    {
        gm.CalculateDistance();
        pos = transform.position;
    }

    /// <summary>
    /// Overriden ToString to grab the objects name and position.
    /// </summary>
    /// <returns>Name and position</returns>
    public override string ToString() { 
        return "Name: " + npc.name + " Position: " + pos + " Status: " + status; 
    }

    /// <summary>
    /// Overriden Equals to check if two NPC's are the same
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public override bool Equals(object other)
    {
        // If other is not of type NPC
        if(!(other is NPC)) { return false; }
        // If other does not have the same name as this NPC
        if(((NPC)other).name != this.name) { return false; }
        return true;
    }
}
