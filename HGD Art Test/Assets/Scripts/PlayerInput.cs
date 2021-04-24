using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public bool q_Input { get; private set; }
    public bool space_Input { get; private set; }
    public bool esc_Input { get; private set; }
    public bool tab_Input { get; private set; }

    private void Update()
    {
        q_Input = Input.GetKeyDown(KeyCode.Q);
        space_Input = Input.GetKeyDown(KeyCode.Space);
        esc_Input = Input.GetKeyDown(KeyCode.Escape);
        tab_Input = Input.GetKeyDown(KeyCode.Tab);
    }
}
