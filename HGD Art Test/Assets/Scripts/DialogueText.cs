using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueText : Dialogue
{
    [SerializeField] private string input;
    private TextMeshPro textContainer;

    private void Awake()
    {
        textContainer = GetComponent<TextMeshPro>();

        StartCoroutine(printText(input, this.textContainer));
    }
}
