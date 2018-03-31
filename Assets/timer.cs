using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class timer {
	public static Stopwatch sw;
	private float elapsedTime;

	// Use this for initialization
	void Start () {
		sw = new Stopwatch ();
		sw.Start ();
	}
	
	public void stop(){
		elapsedTime = (float)sw.ElapsedMilliseconds;
		sw.Stop;
	}

	public void gameOver(){
		DontDestroyOnLoad (this);
		SceneManager.LoadScene ("scoreScene");
	}
}
