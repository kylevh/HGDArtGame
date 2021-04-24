 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prompter : MonoBehaviour
{
    public GameObject dialogPromptBoard;
    public DistToNPC distChecker;
    private GameObject pBoard;

    void Awake()
    {
        distChecker = FindObjectOfType<DistToNPC>();
        pBoard = Instantiate(dialogPromptBoard, new Vector3(0, 2, 0), new Quaternion(0, 0, 0, 0));
    }

    void FixedUpdate()
    {
        foreach (NPC i in distChecker.npcList)
        {
            if(i.getStatus() == 2)
            {
                pBoard.transform.SetParent(i.transform);
                pBoard.transform.localPosition = i.offset; //Sets dialogue prompt position to Vector3 value from NPC script (for easier adjustments per NPC)
                //Debug.Log("Reposition Prompt Board!!!");
            }
        }
    }
}
