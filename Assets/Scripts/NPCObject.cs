using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCObject : InteractableObject
{
    public string npcName;
    public string[] lines;
    public DialogueUI dialogueUI;

    protected override void Interact()
    {
        dialogueUI.Show(npcName, lines);
    }
}
