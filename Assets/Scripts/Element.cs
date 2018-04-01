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

	private int x, y;

	// Use this for initialization
	void Start () {
		mine = Random.value < 0.15;
		if (mine)
			mineNum++;

		x = (int)Mathf.Round(transform.position.x / 2.5f);
		y = (int)Mathf.Round(transform.position.y / 2.5f);
		myGrid.elements [x, y] = this;
	}

	void OnMouseUpAsButton(){
//		Debug.Log (timer.getTime());

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
		else if (adjacentCount == 0)
			myGrid.findAdj (x, y);
		else
			GetComponent<SpriteRenderer> ().sprite = emptyTextures [adjacentCount];
	}

	public bool isCovered(){
		return (GetComponent<SpriteRenderer> ().sprite.texture.name == "ice");
	}

	public void loadEmptyTexture(){
		GetComponent<SpriteRenderer> ().sprite = emptyTextures [0];
	}
}
