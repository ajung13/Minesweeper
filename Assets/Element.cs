using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour {
	public static bool gameOver;
	public bool mine;

	public Sprite[] emptyTextures;
	public Sprite mineTexture;

	// Use this for initialization
	void Start () {
		mine = Random.value < 0.15;
//		loadTexture(1);

		int x = (int)(transform.position.x / 2.5);
		int y = (int)(transform.position.y / 2.5);
		myGrid.elements [x, y] = this;
	}

	void OnMouseUpAsButton(){
		if (gameOver)
			return;
		
		if (mine) {
			myGrid.uncoverMines ();
			print ("YOU LOSE");
			gameOver = true;
		} else {
			int x = (int)(transform.position.x / 2.5);
			int y = (int)(transform.position.y / 2.5);
			loadTexture (myGrid.adjacentMines (x, y));
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
