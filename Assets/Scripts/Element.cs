using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour {
	public static bool gameOver;
	public static int mineNum;
	public bool mine;

	public Sprite[] emptyTextures;
	public Sprite mineTexture;
	public Sprite findMine;

	// Use this for initialization
	void Start () {
		mine = Random.value < 0.15;
		if (mine)
			mineNum++;

		int x = (int)(transform.position.x / 2.5);
		int y = (int)(transform.position.y / 2.5);
		myGrid.elements [x, y] = this;
	}

	void OnMouseUpAsButton(){
		if (gameOver) {
			gameOver = false;
			timer.gameOver ();
			return;
		}
		
		if (mine) {
			myGrid.uncoverMines ();
			print ("YOU LOSE");
			gameOver = true;
			timer.stop ();
		} else {
			int x = (int)(transform.position.x / 2.5);
			int y = (int)(transform.position.y / 2.5);
			loadTexture (myGrid.adjacentMines (x, y));
			myGrid.gameClearCheck ();
		}
	}

	void OnMouseOver(){
		if (Input.GetMouseButtonDown (1))
			GetComponent<SpriteRenderer> ().sprite = findMine;
	}

	public void loadTexture(int adjacentCount){
		if (mine)
			GetComponent<SpriteRenderer> ().sprite = mineTexture;
		else if (adjacentCount == 0) {
			int x = (int)(transform.position.x / 2.5);
			int y = (int)(transform.position.y / 2.5);
			Debug.Log ("googogogo");
			myGrid.findAdj (x, y);
		}
		else
			GetComponent<SpriteRenderer> ().sprite = emptyTextures [adjacentCount];
	}

	public bool isCovered(){
		return (GetComponent<SpriteRenderer> ().sprite.texture.name == "ice");
	}

	public void loadTexture(){
		GetComponent<SpriteRenderer> ().sprite = emptyTextures [0];
	}
}
