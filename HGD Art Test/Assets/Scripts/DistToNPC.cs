using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// <list type="table">
///     <item>Author:
///         <description>Vincent Allen</description>
///     </item>
///     <item>
///         <description>Calculates distance from player to all NPC's</description>
///     </item>
///     <item>
///         <description>Sets NPC status based on that distance</description>
///     </item>
/// </list>
/// <see cref="NPC"/> Hooks into NPC objects in the scene
/// </summary>
public class DistToNPC : MonoBehaviour
{
    public GameObject player;

    public NPC[] npcList;

    [Tooltip("The max distance you want the NPC to activate from")]
    public float activationRange = 5;

    // Stores the position of the player, helps with reducing line-length
    private Vector3 pPos;

    private void Awake()
    {
        npcList = FindObjectsOfType<NPC>();
        pPos = player.transform.position;
    }

    void Update()
    {
        // Only checks distance if the player has moved
        if (pPos != player.transform.position)
        {
            CalculateDistance();
        }
        pPos = player.transform.position;
        GizmoDraw();
    }

    /// <summary>
    /// Calculates the distance between the player and NPC's
    /// </summary>
    public void CalculateDistance()
    {
        // Loops through each NPC for distance calculations
        foreach (NPC i in npcList)
        {

            // Distance function for two points on a 3D plane
            double dist = Mathf.Sqrt(((pPos.x - i.pos.x) * (pPos.x - i.pos.x)) + ((pPos.y - i.pos.y) * (pPos.y - i.pos.y)) + ((pPos.z - i.pos.z) * (pPos.z - i.pos.z)));
            // Stores i's distance to the player onto the NPC itself
            i.setDist(dist);

            // Checks if the player is within the activationRange of the NPC
            if (i.getDist() <= activationRange)
            {
                // The player is within i's activation range, so set its status to 1 and check to make sure it's not contesting with any other NPC's
                i.setStatus(1);
                ContestCheck(i);
            }
            // Otherwise, the player is not within this NPC's activated range
            else
            {
                i.setStatus(0);
            }
        }
    }

    /// <summary>
    /// <list type="table">
    ///     <item>
    ///         <description>Checks to see if NPC n is the only NPC that has the player within its activation range</description>
    ///     </item>
    ///     <item>
    ///         <description>If there are other activated NPC's, then determine which NPC is closer and set their status accordingly</description>
    ///     </item>
    /// </list>
    /// </summary>
    /// <param name="n">NPC who's status we're determining</param>
    public void ContestCheck(NPC n)
    {
        // NPC variable to store which NPC is closest, starts with n
        NPC closestNPC = n;

        foreach (NPC i in npcList)
        {
            //Debug.Log(closestNPC.ToString() + "   Distance to player: " + closestNPC.getDist());
            // If i is closer to the player than the current closest NPC, and the closest NPC is at least within activation range, then make i the new closest NPC
            if (i.getDist() <= closestNPC.getDist() && closestNPC.getStatus() >= 1)
            {
                // Sets the current closestNPC's status back to 1 in the event it was previously 2
                closestNPC.setStatus(1);
                // Sets closestNPC to i
                closestNPC = i;
                // Sets the new closestNPC's status to 2
                closestNPC.setStatus(2);
            }
            // If i's status is already 2 and it is not the same as the closestNPC, set i's status back to 1
            if(i.getStatus() == 2 && !i.Equals(closestNPC))
            {
                i.setStatus(1);
            }
        }
    }

    /// <summary>
    /// Draws gizmo lines in the scene editor to indicate what status the npc is in relative to the player distance
    /// </summary>
    public void GizmoDraw()
    {
        foreach (NPC i in npcList)
        {
            // Stores a color for easier gizmo color changing
            Color gizmoColor = Color.green;

            // Blue indicated the NPC is within activation range, but not prompting the player
            if (i.getStatus() == 1) { gizmoColor = Color.blue; }
            // Green means the npc is prompting the player to talk with them
            else if (i.getStatus() == 2) { gizmoColor = Color.green; }
            // Red means the npc is not within activation range
            else { gizmoColor = Color.red; }

            Debug.DrawLine(pPos, i.pos, gizmoColor);
        }
    }
}
