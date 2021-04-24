using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameState { Roaming, inDialogue }

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
