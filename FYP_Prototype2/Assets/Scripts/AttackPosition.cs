using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;

public class AttackPosition : MonoBehaviour {
	public Button yourButton;
	public Button itemButton;
	public Button skillButton;
    public Button turnEndButton, moveButton;
    //public GameObject thisO;
    // Use this for initialization
    void Start () {
		Button abtn = yourButton.GetComponent<Button>();
		Button ibtn = itemButton.GetComponent<Button>();
		Button sbtn = skillButton.GetComponent<Button>();
        Button tbtn = turnEndButton.GetComponent<Button>();
        Button mbtn = moveButton.GetComponent<Button>();
        //GameObject buttonA = GameObject.Find("Attack");
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = yourButton.transform.position;
        Vector3 pos2 = itemButton.transform.position;
        Vector3 pos3 = skillButton.transform.position;
        Vector3 pos4 = turnEndButton.transform.position;
        Vector3 pos5 = turnEndButton.transform.position;
        Vector3 inPos;
        if (BoardM.selectedChessman != null)
        {
            //Vector3 posT = this.transform.position;

            pos.x = BoardM.selectedChessman.transform.position.x + 1.2f;
            pos.z = BoardM.selectedChessman.transform.position.z + 0.8f;
            pos.y = BoardM.selectedChessman.transform.position.y + 1f;
            //pos.z = BoardM.selectedChessman.transform.position.z;
            //pos.y = BoardM.selectionY;
            yourButton.transform.position = pos;


            pos2.x = BoardM.selectedChessman.transform.position.x + 1.2f;
            pos2.z = BoardM.selectedChessman.transform.position.z + -0.4f;
            pos2.y = BoardM.selectedChessman.transform.position.y + 1f;
            //pos.z = BoardM.selectedChessman.transform.position.z;
            //pos.y = BoardM.selectionY;
            itemButton.transform.position = pos2;


            pos3.x = BoardM.selectedChessman.transform.position.x + 1.2f;
            pos3.z = BoardM.selectedChessman.transform.position.z + 0.2f;
            pos3.y = BoardM.selectedChessman.transform.position.y + 1f;
            //pos.z = BoardM.selectedChessman.transform.position.z;
            //pos.y = BoardM.selectionY;
            skillButton.transform.position = pos3;


            pos4.x = BoardM.selectedChessman.transform.position.x + 1.2f;
            pos4.z = BoardM.selectedChessman.transform.position.z - 1.0f;
            pos4.y = BoardM.selectedChessman.transform.position.y + 1f;
            //pos.z = BoardM.selectedChessman.transform.position.z;
            //pos.y = BoardM.selectionY;
            turnEndButton.transform.position = pos4;
            pos5.x = BoardM.selectedChessman.transform.position.x + 1.2f;
            pos5.z = BoardM.selectedChessman.transform.position.z - 1.6f;
            pos5.y = BoardM.selectedChessman.transform.position.y + 1f;
            //pos.z = BoardM.selectedChessman.transform.position.z;
            //pos.y = BoardM.selectionY;
            moveButton.transform.position = pos5;
        }
        else
        {
            inPos.x = 100;
            inPos.y = 100;
            inPos.z = 100;
            turnEndButton.transform.position = inPos;
            skillButton.transform.position = inPos;
            itemButton.transform.position = inPos;
            yourButton.transform.position = inPos;
            moveButton.transform.position = inPos;

        }
    }
}
