using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Kyle Huynh
 * 
 * Centralize all player input into one script
 */

public class PlayerInput : MonoBehaviour
{
    public bool q_Input { get; private set; }
    public bool interact { get; private set; }
    public bool space_Input { get; private set; }
    public bool esc_Input { get; private set; }
    public bool tab_Input { get; private set; }

    private void Update()
    {
        q_Input = Input.GetKeyDown(KeyCode.Q);
        interact = Input.GetKeyDown(KeyCode.F);
        space_Input = Input.GetKeyDown(KeyCode.Space);
        esc_Input = Input.GetKeyDown(KeyCode.Escape);
        tab_Input = Input.GetKeyDown(KeyCode.Tab);
    }
}
