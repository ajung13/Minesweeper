using System.Collections;
using UnityEngine;

public class myGrid {
	public static int w = 10;
	public static int h = 13;
	public static Element[,] elements = new Element[w, h];

	public static void uncoverMines(){
		foreach (Element elem in elements) {
			if (elem.mine)
				elem.loadTexture (0);
		}
	}

	public static bool mineAt(int x, int y){
		if (x >= 0 && y >= 0 && x < w && y < h)
			return elements [x, y].mine;
		return false;
	}

	public static int adjacentMines(int x, int y){
		int count = 0;

		if (mineAt (x, y + 1))
			++count;
		if (mineAt (x + 1, y + 1))
			++count;
		if (mineAt (x + 1, y))
			++count;
		if (mineAt (x + 1, y - 1))
			++count;
		if (mineAt (x, y - 1))
			++count;
		if (mineAt (x - 1, y - 1))
			++count;
		if (mineAt (x - 1, y))
			++count;
		if (mineAt (x - 1, y + 1))
			++count;

		return count;
	}
		
	public static void gameClearCheck(){
		int covered = 0;
		foreach (Element elem in elements) {
			if (elem.isCovered ())
				covered++;
		}

		if (covered == Element.mineNum)
			timer.gameClear ();
	}

	public static void findAdj(int x, int y){
		int tmp = adjacentMines (x, y);
		elements [x, y].loadTexture ();
		Debug.Log ("findAdj with parameter " + x + ", " + y);

		for (int i = -1; i <= 1; i++) {
			for (int j = -1; j <= 1; j++) {
				if (i == 0 && j == 0)
					continue;
				if (x + i < 0 || y + j < 0 || x + i >= w || y + j >= h)
					continue;
				tmp = adjacentMines (x + i, y + j);
				if (tmp == 0)
					findAdj (x + i, y + j);
				else {
					elements [x + i, y + j].loadTexture (tmp);
					gameClearCheck ();
				}
			}
		}
	}
}
