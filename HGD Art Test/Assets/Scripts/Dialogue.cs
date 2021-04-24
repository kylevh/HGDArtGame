using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour
{

    //Will print each individual character of text
    protected IEnumerator printText(string input, TextMeshPro tContainer, Color tColor, TMPro.TMP_FontAsset tFont)
    {
        for (int i = 0; i < input.Length; i++)
        {
            tContainer.color = tColor;
            tContainer.font = tFont;
            tContainer.text += input[i];
            yield return new WaitForSeconds(0.1f);
        }
    }
}
