using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


[System.Serializable]
public class Dialogue
{
    [Header("Customize Text")]
    [SerializeField] [TextArea] List<string> lines; //The dialogue lines
    [SerializeField] public string name;
    [SerializeField] public TMP_FontAsset textFont; //Font for specific NPC
    [SerializeField] public Color textColor; //Color for specific NPC
    [SerializeField] public TextMeshProUGUI textContainer; //Not in use anymore?

    [Header("Timing")]
    [SerializeField] public float charDelay = 0.05f; //Lower the number, faster text will be displayed

    [Header("Voice")]
    [SerializeField] public AudioClip[] sound; //Array of sounds that will play for every character (randomized in DialogueManager)

    [Header("Character Sprite")]
    [SerializeField] public Sprite characterSprite; //Head shot of character that will be displayed
    [SerializeField] public Image imageHolder; 

    public List<string> Lines 
    {
        get { return lines; }
    }
}
