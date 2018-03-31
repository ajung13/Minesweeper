using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour {
	public static bool gameOver;
	public static int mineNum;
	public bool mine;

	public Sprite[] emptyTextures;
	public Sprite mineTexture;

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

	public void loadTexture(int adjacentCount){
		if (mine)
			GetComponent<SpriteRenderer> ().sprite = mineTexture;
		else
			GetComponent<SpriteRenderer> ().sprite = emptyTextures [adjacentCount];
	}

	public bool isCovered(){
		return (GetComponent<SpriteRenderer> ().sprite.texture.name == "ice");
	}
}
