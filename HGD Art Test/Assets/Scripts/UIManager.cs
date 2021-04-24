using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* User Interface Manager 
 * by Kyle Huynh
 * 
 * Anything that wants to manipulate the HUD in-game should pass through this script
 * Handles all the user interface updates
 * 
 */

[RequireComponent(typeof(PlayerInput))]
public class UIManager : MonoBehaviour
{
    public bool inDialogue = false;

    private void Update()
    {
        
    }

    void dialogueCheck()
    {
        PlayerInput.input.interact;
    }
}
