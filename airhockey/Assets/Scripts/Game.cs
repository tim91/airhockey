using UnityEngine;
using System.Collections;

public class Game {

	private static bool gameStarted=false;
	
	public static bool isGameStarted(){
		return gameStarted;
	}
	public static void startGame(){
		gameStarted = true;
		GUIView.setCamera ();
	}
}
