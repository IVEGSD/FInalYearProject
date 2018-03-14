using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("escape"))
            Application.Quit();
    }

    public void startGame()
    {

    }

    public void changeSetting()
    {

    }

    public void exitGame()
    {
        Application.Quit();
    }
}
