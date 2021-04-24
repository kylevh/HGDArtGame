using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

/* User Interface Manager 
 * Author: Kyle Huynh
 * 
 * Anything that wants to manipulate the HUD in-game should pass through this script
 * Handles all the user interface updates
 * MUST TAG OBJECT WITH 'UIManager'
 * 
 * DialogueManager handles most of the dialogue UI so this technically doesn't handle all the UI :/
 * 
 * 
 * Must set CinemachineTargetGroup in inspector
 * Must set dialogueCam gameobject
 * Need to optimize and remove FindObjectOfType (do later)
 * 
 */

public class UIManager : MonoBehaviour
{
    public static UIManager ui;
    public Prompter prompt;
    public PlayerInput inputs;
    public bool inDialogue = false;
    public CinemachineTargetGroup targetGroup;
    public GameObject dialogueCam;

    public void Awake()
    {
        ui = this;
        prompt = FindObjectOfType<Prompter>();
        inputs = FindObjectOfType<PlayerInput>();
    }


    public void fadeOutPrompt()
    {
        prompt.fadeOut();
    }

    public void fadeInPrompt()
    {
        prompt.fadeIn();
    }

    public void setTarget(GameObject obj)
    {
        targetGroup.m_Targets[1].target = obj.transform;
    }

    public void enableDialogueCam()
    {
        dialogueCam.SetActive(true);
    }

    public void disableDialogueCam()
    {
        dialogueCam.SetActive(false);
    }

}
