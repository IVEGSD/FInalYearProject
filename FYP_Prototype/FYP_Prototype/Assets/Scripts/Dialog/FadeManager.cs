using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeManager : MonoBehaviour {

    public Animator fadeEffect;

    [Header("Get the dialogue is end or not")]
    public Animator dialogueAnimation;  //showing the dialogue -> button to top animation

    void Start () {
        fadeEffect.SetBool("isFadeIn", true);
	}
	
	// Update is called once per frame
	void Update () {
		if (dialogueAnimation.GetBool ("IsOpen") == false) 
		{
			fadeEffect.SetBool ("isFadeIn", false);
		} 
		else 
		{
			fadeEffect.SetBool ("isFadeIn", true);
		}


        if (Input.GetKeyDown(KeyCode.B))
        {
            fadeEffect.SetBool("isFadeIn", false);
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            fadeEffect.SetBool("isFadeIn", true);
        }
    }
}
