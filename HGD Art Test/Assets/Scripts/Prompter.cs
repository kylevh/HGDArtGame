 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Prompter : MonoBehaviour
{
    public GameObject dialogPromptBoard;
    public DistToNPC distChecker;
    private GameObject pBoard;

    //kyle's vars
    public bool promptVisible = true;

    void Awake()
    {
        distChecker = FindObjectOfType<DistToNPC>();
        pBoard = Instantiate(dialogPromptBoard, new Vector3(0, 2, 0), new Quaternion(0, 0, 0, 0));
        fadeOut(); //Prompt box will immeditely fade out on start
    }

    void FixedUpdate()
    {
        updatePromptPosition();
        dialoguePromptUpdate();
    }

    void updatePromptPosition()
    {
        foreach (NPC i in distChecker.npcList)
        {

            if (i.getStatus() == 2)
            {
                pBoard.transform.SetParent(i.transform);
                pBoard.transform.localPosition = i.offset; //Sets dialogue prompt position to Vector3 value from NPC script (for easier adjustments per NPC)
                //Debug.Log("Reposition Prompt Board!!!");
            }
        }
    }


    //Kyle's random messy code
    bool inRangeOfAnyNPC()  //Will check if any NPC is currently in range of Player
    {
        int inRange = 0;
        int outOfRange = 0;

        foreach (NPC i in distChecker.npcList)
        {

            if (i.getStatus() == 2 || i.getStatus() == 1) //If anyone is in range, change count
            {
                inRange++;
            }
            else if (i.getStatus() == 0) //If out of range
            {
                outOfRange++;
            }
        }

        if (inRange > 0) return true;
        if (inRange == 0) return false;

        return false;
    }

    void dialoguePromptUpdate() //Updates dialogue box to either fade in or fade out depending on if there's any NPCs in range
    {
        if (inRangeOfAnyNPC()) fadeIn();
        else if (!inRangeOfAnyNPC()) fadeOut();
    }

    void fadeOut() //Fades out dialogue box and text
    {
        if (promptVisible)
        {
            LeanTween.color(pBoard, Color.clear, .4f);
            promptVisible = false;
        }
    }

    void fadeIn()
    {
        if (!promptVisible)
        {
            LeanTween.color(pBoard, Color.white, .4f);
            promptVisible = true;
        }
    }
}
