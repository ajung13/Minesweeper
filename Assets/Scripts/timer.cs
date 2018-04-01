using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour {
	public static Stopwatch sw;
	private static float elapsedTime;

	// Use this for initialization
	void Start () {
		Element.mineNum = 0;
		sw = new Stopwatch ();
		sw.Start ();
	}
	
	public static void stop(){
		elapsedTime = (float)sw.ElapsedMilliseconds;
		sw.Stop ();
	}

	public static void gameOver(){
//		DontDestroyOnLoad (this);
		SceneManager.LoadScene ("Scenes/gameOverScene");
	}

	public static float getTime(){
		return elapsedTime;
	}

	public static void gameClear(){
		SceneManager.LoadScene ("Scenes/scoreScene");
	}
}
