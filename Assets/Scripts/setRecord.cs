using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setRecord : MonoBehaviour {
	public Text myScore;
//	public Text bestRecord;

	// Use this for initialization
	void Start () {
		myScore.text = "Elapsed Time: " + timer.getTime() + " seconds";
	}
}
