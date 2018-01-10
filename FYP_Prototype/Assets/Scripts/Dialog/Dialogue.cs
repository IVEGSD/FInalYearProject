using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue {

	public string name;

	[TextArea(3, 10)]   //set the input prompt width and height of the Inspector
	public string[] sentences;

}
