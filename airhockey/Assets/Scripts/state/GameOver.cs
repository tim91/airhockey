using UnityEngine;
using System.Collections;

public class GameOver : GameState {


	public void showGUI () {
		showWaiting ();
	}
	public void modifyCamera(Camera camera){
		camera.transform.RotateAround (new Vector3 (0, camera.transform.position.y, 0), new Vector3 (0, 1, 0), 1.0f);
	}
	void showWaiting(){
		string msg = buildMsg();
		showWindow ("Game Over", msg);
	}
	string buildMsg(){
		string msg="";
		if (PlayerHelper.getMyScore () > PlayerHelper.getOponentScore ()) {
			msg = "You WIN!!!";
		} else {
			msg="You LOSE!!!";
		}
		
		return msg;
	}
	public void showWindow(string title,string text) {
		GUI.ModalWindow (1, new Rect (Screen.width/2-GUIConstants.LABEL_WIDTH/2, 100.0f, GUIConstants.LABEL_WIDTH, GUIConstants.LABEL_HEIGHT), delegate(int id) {
			GUILayout.Label (text);
		}, title);
	}

}
