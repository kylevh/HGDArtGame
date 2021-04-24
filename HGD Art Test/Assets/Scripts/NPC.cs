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
    public GameObject npc;    // The current position of the object
    public Vector3 pos;
    public Vector3 offset;

    private double distToPlayer;  // Stores the current distance to the player
    public int status = 0;

    // TEMPORARY
    private DistToNPC gm;
    public bool isMoving;

    [SerializeField] Dialogue dialogue;

    private void Awake()
    {
        npc = gameObject;
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

    public void startTalk()
    {
        if (!DialogueManager.instance.inDialogue)
        {
            Debug.Log("startTalk played");
            StartCoroutine(DialogueManager.instance.showDialogue(dialogue));
        }
    }

    public void exitTalk()
    {
        if (DialogueManager.instance.inDialogue)
            DialogueManager.instance.closeDialogue();
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

    public override string ToString()
    {
        return "Name: " + npc.name + " Position: " + pos + " Status: " + status;
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
