using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public Text nameText;
	public Text dialogueText;

	public Animator animator;
    public Animator fadeEffect;

    public GameObject TalkButton;

	private Queue<string> sentences;
    
	void Start () {
		sentences = new Queue<string>();
	}

	public void StartDialogue (Dialogue dialogue)
	{
		animator.SetBool("IsOpen", true);
        fadeEffect.SetBool("isTalk", true);
        TalkButton.SetActive(false);


        nameText.text = dialogue.name[0];

		sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}

	public void DisplayNextSentence ()
	{
        Debug.Log(sentences.Count);
        if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}

		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence (string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
            
			dialogueText.text += letter;
            yield return new WaitForSeconds(0.02f);
            yield return null;
		}
	}

	void EndDialogue()
	{
		animator.SetBool("IsOpen", false);
        fadeEffect.SetBool("isTalk", false);
        TalkButton.SetActive(true);
    }

}
