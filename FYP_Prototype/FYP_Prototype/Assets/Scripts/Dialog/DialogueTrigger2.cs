using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger2 : MonoBehaviour{

    public Dialogue dialogue;

    private void Start()
    {
        TriggerDialogue();
    }

    public void TriggerDialogue()
    {
         FindObjectOfType<DialogueManager2>().StartDialogue(dialogue);
    }
    
}
