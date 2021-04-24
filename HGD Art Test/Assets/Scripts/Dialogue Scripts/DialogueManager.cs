using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Based off:
// https://www.youtube.com/watch?v=2CmG7ZtrWso&ab_channel=GameDevExperiments

/* Events (startDialogue, endDialogue)
 * Functions -
 *      showDialogue (has to be called through NPC and pass Dialogue class, will start dialogue and update GameState)
 *      closeDialogue (closes dialogue box and resets everything, can be called anywhere)
 *      HandleUpdate (Switches GameState of PlayerController from Roaming to Dialogue mode)
 *      
 *      a ton of bugs in this but i'm working on it :3
 *      
 * Author: Kyle Huynh
 */

public class DialogueManager : MonoBehaviour
{
    [SerializeField] GameObject dialogueBox; //Game object that holds everything
    [SerializeField] TextMeshProUGUI dialogue; //Text that will be displayed on HUD
    [SerializeField] TextMeshProUGUI npcName; //name
    public PlayerInput inputs;
    public PlayerController controller;
    public bool inDialogue;

    public static DialogueManager instance { get; private set; }
    public event Action startDialogue;
    public event Action endDialogue;

    Dialogue dialog;
    [SerializeField] int currentLine = 0;
    [SerializeField] bool typing;

    private void Awake()
    {
        instance = this;
        inputs = FindObjectOfType<PlayerInput>();
        controller = FindObjectOfType<PlayerController>();
    }

    public void HandleUpdate()
    {
        if(inputs.interact && !typing)
        {
            currentLine++;
            if (currentLine < dialog.Lines.Count) //Go to next line of dialogue if there is more lines
            {
                StartCoroutine(printText(dialog.Lines[currentLine], Color.black, .05f, dialog.sound, dialog.textFont));
            }
            else //If there are no lines left and interact button is pressed, close
            {
                closeDialogue();
            }
        }
    }

    public IEnumerator showDialogue(Dialogue dialog)
    {
        UIManager.ui.enableDialogueCam();
        npcName.text = "";
        inDialogue = true;
        controller.canMove = false;
        yield return new WaitForEndOfFrame();

        startDialogue?.Invoke();

        this.dialog = dialog;
        dialogueBox.SetActive(true); //Will change to animation when I get the chance
        StartCoroutine(printText(dialog.Lines[0], Color.black, .05f, dialog.sound, dialog.textFont));
        npcName.text = dialog.name;
    }

    public void closeDialogue()
    {
        UIManager.ui.disableDialogueCam();
        controller.canMove = true;
        inDialogue = false;
        currentLine = 0;
        dialogueBox.SetActive(false); //END OF DIALOGE
        endDialogue?.Invoke();
    }



    /* Takes in dialogue text, color, font, etc... and prints them out one by one.
     * also updates variables that tell us whether or not we're in dialogue for other
     * scripts to know.
     */
    protected IEnumerator printText(string input, Color tColor, float charDelay, AudioClip[] sound, TMP_FontAsset tFont) 
    {
        typing = true;
        inDialogue = true;
        dialogue.text = "";
        dialogue.font = tFont;
        dialogue.color = tColor;

        //Types each character in string
        for (int i = 0; i < input.Length; i++)
        {
            dialogue.text += input[i];

            if (i % 2 == 0)
                SoundManager.instance.playSound(chooseRandomVoiceClip(sound));
            yield return new WaitForSeconds(charDelay);
        }
        typing = false;
    }


    AudioClip chooseRandomVoiceClip(AudioClip[] abc)
    {
        int index = UnityEngine.Random.Range(0, abc.Length);
        return abc[index];

    }

}
