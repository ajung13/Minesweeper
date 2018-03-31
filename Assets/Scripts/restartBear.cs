using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartBear : MonoBehaviour {

	void OnMouseUpAsButton(){
		SceneManager.LoadScene ("mainScene");
	}
}
