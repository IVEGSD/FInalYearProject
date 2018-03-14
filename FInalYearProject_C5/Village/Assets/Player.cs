using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    Rigidbody playerRigidbody;
    float moveX;
    float moveZ;
    float speed = 8;

    private GameObject triggeringNpc;
    private bool triggering;

    public GameObject npcText;

	// Use this for initialization
	void Start () {
        playerRigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");
        playerRigidbody.AddForce(new Vector3(speed * moveX,0, speed * moveZ));

        if (triggering)
        {
            npcText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
                
               print("Hello player, i am" + triggeringNpc);
        } else
            npcText.SetActive(false);
	}

    void OnTriggerEnter(Collider other) {
        if(other.tag == "NPC")
        {
            triggering = true;
            triggeringNpc = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.tag == "NPC")
        {
            triggering = false;
            triggeringNpc = null;
        }
    }



}
