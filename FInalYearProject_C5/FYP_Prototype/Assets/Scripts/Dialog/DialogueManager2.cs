using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager2 : MonoBehaviour {
    
    [Header("Dialogue Components[Name][Dialog]")]
    public Text nameText;       //canvas.text for character name
    public Text dialogueText;   //canvas.text for dialogue
    string[] names;             //store the character name from DialogTrigger.cs
    
    public Animator dialogueAnimation;  //showing the dialogue -> button to top animation

    [Header("Change Character Image Color")]
    public CharacterColorManger[] characterImages;

    private Queue<string> sentences;    //temp to store the dialogue script from DialogueTrigger.cs



    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueAnimation.SetBool("IsOpen", true);  //show the dialogue

        names = dialogue.name;  //store the character's names[] in DialogueTrigger.cs
        //nameText.text = names[0];   //set the name of first talking character
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();  //show the first sentence of first character
    }

    public void DisplayNextSentence()
    {
        //Debug.Log(sentences.Count); //how many the sentence is, how many the count is.

        if (sentences.Count == 0)   //when click after the last sentence is shown, the dialogue exit.
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            if (letter.Equals('*')){        //* is second character
                nameText.text = names[1];
                characterImages[0].ChangeBlack(true);
                characterImages[1].ChangeBlack(false);
            }
            else if (letter.Equals('#'))    //# is first character
            {
                nameText.text = names[0];
                characterImages[0].ChangeBlack(false);
                characterImages[1].ChangeBlack(true);
            }
            else
            {
                dialogueText.text += letter;
            }

            yield return new WaitForSeconds(0.02f);
            //yield return null;
        }
    }

    void EndDialogue()
    {
        dialogueAnimation.SetBool("IsOpen", false);
    }
}
