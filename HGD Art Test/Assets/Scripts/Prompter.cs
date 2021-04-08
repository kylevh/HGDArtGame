using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prompter : MonoBehaviour
{
    public GameObject dialogPromptBoard;

    public DistToNPC distChecker;
    private GameObject pBoard;

    // Start is called before the first frame update
    void Awake()
    {
        distChecker = FindObjectOfType<DistToNPC>();
        pBoard = Instantiate(dialogPromptBoard, new Vector3(0, 2, 0), new Quaternion(0, 0, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        foreach (NPC i in distChecker.npcList)
        {
            if(i.getStatus() == 2)
            {
                pBoard.transform.SetParent(i.transform);
                pBoard.transform.localPosition = new Vector3(0, 2, 0);
                //Debug.Log("Reposition Prompt Board!!!");
            }
        }
    }
}
