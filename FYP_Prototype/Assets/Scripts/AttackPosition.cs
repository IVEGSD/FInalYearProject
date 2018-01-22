using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;

public class AttackPosition : MonoBehaviour {
	public Button yourButton;
	//public GameObject thisO;
	// Use this for initialization
	void Start () {
		Button abtn = yourButton.GetComponent<Button>();
		//GameObject buttonA = GameObject.Find("Attack");
	}
	
	// Update is called once per frame
	void Update () {
		//Vector3 posT = this.transform.position;
		Vector3 pos = yourButton.transform.position;

		pos.x = BoardM.selectedChessman.transform.position.x + 1.2f;
		pos.z = BoardM.selectedChessman.transform.position.z + 0.8f;
		pos.y = BoardM.selectedChessman.transform.position.y +0.5f;
		//pos.z = BoardM.selectedChessman.transform.position.z;
		//pos.y = BoardM.selectionY;
		yourButton.transform.position = pos;
	}
}
