using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable {
    public string[] dialogue;  //TODO JSON Files for more dialogs
    public string name;

    public override void Interact() {
        DialogueSystem.instance.AddNewDialogue(dialogue, name);
    }
}
