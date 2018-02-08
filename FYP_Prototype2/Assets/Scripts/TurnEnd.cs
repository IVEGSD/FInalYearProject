using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;


public class TurnEnd : MonoBehaviour {
	public Button yourButton;
	public Text btext = null;
	public static int round = 1;
	string s;
	void Start()
	{
		
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);

	
	}

	void TaskOnClick()
	{
		round++;

		//Move2.isWhite = true;
		//CubeMove.isWhite = true;
		//Move3.isWhite = true;

		btext.text = "Round: "+round;
	}

}
