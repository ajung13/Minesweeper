using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour {
	public bool mine;

	public Sprite[] emptyTextures;
	public Sprite mineTexture;

	// Use this for initialization
	void Start () {
		mine = Random.value < 0.15;
//		loadTexture(1);

		int x = (int)transform.position.x;
		int y = (int)transform.position.y;
		myGrid.elements [x, y] = this;
	}

	void OnMouseUpAsButton(){
		if (mine) {
//			myGrid.uncoverMines ();
//			print ("YOU LOSE");
			loadTexture(2);
		} else {
			int x = (int)transform.position.x;
			int y = (int)transform.position.y;
//			loadTexture (myGrid.adjacentMines (x, y));
			loadTexture(1);
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
