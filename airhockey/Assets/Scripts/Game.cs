using UnityEngine;
using System.Collections;

public class Game {

	private static bool gameStarted=true;
	private static GameState state=new Playing ();
	public static bool isGameStarted(){
		return gameStarted;
	}
	public static void startGame(){
		state = new Playing ();
		gameStarted = true;
		GUIView.setCamera ();
	}
	public static void stopGame(int winPlayerId){
		gameStarted = false;
		state = new GameOver ();

	}
	public static GameState getState(){
		return state;
	}
}
