using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Custom GameState for between roaming around and when you enter dialogue
 * Basically, constantly checking for whether or not you've started a dialogue or 
 * not and if so, change updates so that only DialogueManager handles updates instead
 * of the PlayerController (so there's no movement while talking)
 * 
 */
public enum GameState { Roaming, inDialogue } //In the future, we can add GameStates like "Battle" or "Menu". 

public class GameManager : MonoBehaviour
{
    GameState state;
    [SerializeField] PlayerController playerController;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    void Start()
    {
        DialogueManager.instance.startDialogue += () =>
        {
            state = GameState.inDialogue;
        };

        DialogueManager.instance.endDialogue += () =>
        {
            if (state == GameState.inDialogue)
                state = GameState.Roaming;
        };
    }

    void Update()
    {
        if (state == GameState.Roaming)
        {
            playerController.HandleUpdate();
        }
        else if (state == GameState.inDialogue)
        {
            DialogueManager.instance.HandleUpdate();
        }
    }
}
