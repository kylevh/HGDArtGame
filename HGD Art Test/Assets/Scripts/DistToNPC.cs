using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DistToNPC : MonoBehaviour
{
    public GameObject player;

    public NPC[] npcList;

    [Tooltip("The max distance you want the NPC to activate from")]
    public float activationRange = 5;

    Color gizmoColor = Color.green;
    Vector3 pPos;

    private void Awake()
    {
         npcList = FindObjectsOfType<NPC>();
    }

    // Update is called once per frame
    void Update()
    {
        pPos = player.transform.position;
        // Loops through each NPC for distance calculations
        foreach (NPC i in npcList)
        {
            // Distance function for two points on a 3D plane
            float dist = Mathf.Sqrt(((pPos.x - i.pos.x) * (pPos.x - i.pos.x)) + ((pPos.y - i.pos.y) * (pPos.y - i.pos.y)) + ((pPos.z - i.pos.z) * (pPos.z - i.pos.z)));
            // Checks if the distance is less than or equal to the activation range
            if (dist <= activationRange)
            {
                // Set the gizmo color to red to indicate to dev that we're within activated range
                gizmoColor = Color.red;
                Debug.Log(i.ToString() + "   Distance to player: " + dist);
            }
            // Otherwise, reset gizmo to green to show we're not within activated range
            else gizmoColor = Color.green;
            Debug.DrawLine(pPos, i.pos, gizmoColor);
        }
    }
}
