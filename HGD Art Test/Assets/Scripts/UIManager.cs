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
 */

public class UIManager : MonoBehaviour
{
    public static UIManager ui;
    public Prompter prompt;
    public PlayerInput inputs;
    public bool inDialogue = false;
    public CinemachineTargetGroup targetGroup;

    public void Awake()
    {
        ui = this;
        prompt = FindObjectOfType<Prompter>();
        inputs = FindObjectOfType<PlayerInput>();
    }
    private void LateUpdate()
    {
        enterDialogueCheck();
    }

    void enterDialogueCheck()
    {
        if(inputs.interact)
        {
            if(!inDialogue)
            {
                inDialogue = true;
                prompt.fadeOut();
            }
        }
    }
}
