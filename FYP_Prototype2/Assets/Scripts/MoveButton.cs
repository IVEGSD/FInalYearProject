using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;

public class MoveButton : MonoBehaviour {
    public Button yourButton;


    string s;
    void Start()
    {

        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);


    }

    void TaskOnClick()
    {

            BoardM.whetherMove = true;

       
    }

}