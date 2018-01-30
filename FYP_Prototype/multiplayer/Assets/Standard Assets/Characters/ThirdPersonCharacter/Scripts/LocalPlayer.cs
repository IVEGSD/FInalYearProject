using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.Characters.ThirdPerson;

public class LocalPlayer : NetworkBehaviour {
	// Use this for initialization
	void Start () {
		if (isLocalPlayer) {
			GetComponent<ThirdPersonUserControl>().enabled = true;
		}
	}
}
