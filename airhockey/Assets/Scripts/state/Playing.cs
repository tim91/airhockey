using UnityEngine;
using System.Collections;

public class Playing : GameState {


	public void showGUI () {
		showGameInfo ();
	}
	public void modifyCamera(Camera camera){
		
	}

	void showGameInfo(){
		showMyInfo ();
		showOponentInfo ();
	}
	void showMyInfo(){
		string msg = buildMyInfo ();
		GUI.Label (new Rect (GUIConstants.LABEL_MARGIN,GUIConstants.LABEL_MARGIN, GUIConstants.LABEL_WIDTH, GUIConstants.LABEL_HEIGHT), msg);
	}
	void showOponentInfo(){
		string msg = buildOponentInfo ();
		GUI.Label (new Rect (Screen.width-GUIConstants.LABEL_WIDTH, GUIConstants.LABEL_MARGIN, GUIConstants.LABEL_WIDTH, GUIConstants.LABEL_HEIGHT), msg);
	}
	string buildMyInfo(){
		string msg = "";
		msg+=buildStatus ();
		msg+=buildRoomInfo();
		msg += buildPlayerInfo();
		return msg;
	}
	string buildStatus(){
		string msg="Status: "+PhotonNetwork.connectionStateDetailed.ToString ();
		return msg;
	}
	string buildRoomInfo(){
		string msg = "";
		if (PhotonNetwork.room == null)
			return msg;
		msg+="\nRoom: " + PhotonNetwork.room.name;
		msg+= "\nPlayerCount: " + PhotonNetwork.room.playerCount;
		return msg;
	}
	string buildPlayerInfo(){
		string msg = "";
		if (PlayerHelper.playerExist ()) {
			msg = "\nPlayerName: " + PhotonNetwork.playerName;
			msg += "\nScore: " + PlayerHelper.getMyScore ();
			return msg;
		}
		msg += "\nPlayerName: <Unknown>";
		msg += "\nScore: <Unknown>";
		return msg;
	}
	string buildOponentInfo(){
		string msg = "";
		
		if (PlayerHelper.oponentExist ()) {
			msg += "PlayerName: " + PlayerHelper.getOponentName ();
			msg += "\nScore: " + PlayerHelper.getOponentScore ();
			return msg;
		}
		
		msg = "PlayerName: <Unknown>";
		msg += "\nScore: <Unknown>";
		return msg;
	}
	
	public void showWindow(string title,string text) {
		GUI.ModalWindow (1, new Rect (Screen.width/2-GUIConstants.LABEL_WIDTH/2, 100.0f, GUIConstants.LABEL_WIDTH, GUIConstants.LABEL_HEIGHT), delegate(int id) {
			GUILayout.Label (text);
		}, title);
	}

}
