using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour {
    public static DialogueSystem instance { get; set; }
    public GameObject dialoguePanel;
    public string npcName;
    public List<string> dialogueLines = new List<string>();

    Button continueButton;
    Text dialogueText, nameText;
    int dialogueIndex;

    void Awake () {
        continueButton = dialoguePanel.transform.FindChild("Continue").GetComponent<Button>();
        dialogueText = dialoguePanel.transform.FindChild("Text").GetComponent<Text>();
        nameText = dialoguePanel.transform.FindChild("Name").GetChild(0).GetComponent<Text>();

        continueButton.onClick.AddListener(delegate { ContinueDialogue(); });

        dialoguePanel.SetActive(true);

		if(instance != null && instance != this) {
            Destroy(gameObject);
        } else {
            instance = this;
        }
	}
	

    public void AddNewDialogue(string[] lines, string npcName) {
        dialogueIndex = 0;
        
        foreach(string line in lines) {
            dialogueLines.Add(line);
        }
        this.npcName = npcName;
        CreateDialogue();
    }

    public void CreateDialogue() {
        dialogueText.text = dialogueLines[dialogueIndex];
        nameText.text = npcName;
        dialoguePanel.SetActive(true);
    }

    public void ContinueDialogue() {
         if(dialogueIndex < dialogueLines.Count - 1) {
            dialogueIndex++;
            dialogueText.text = dialogueLines[dialogueIndex];
            Debug.Log(dialogueLines.Count);
        }
         else {
            if(npcName == "level1") {
                GameManager.changeScene(3);
                GameManager.unloadScene(2);
            }
            dialogueLines.Clear();
            dialoguePanel.SetActive(false);
        }
    }
}
