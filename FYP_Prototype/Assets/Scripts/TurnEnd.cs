using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;


public class TurnEnd : MonoBehaviour {
	public Button yourButton;
	public Text btext = null;
	int i = 1;
	string s;
	void Start()
	{
		
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);

	
	}

	void TaskOnClick()
	{
		i++;
		BoardM.m1 = true;
		BoardM.m2 = true;
		BoardM.m3 = true;

		btext.text = "Round: "+i;
	}

}
