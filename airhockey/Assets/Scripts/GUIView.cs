using UnityEngine;
using System.Collections;
public class GUIView : MonoBehaviour {
	
	void OnGUI(){
		showGameInfo();
	}

	void showGameInfo(){
		showMyInfo ();
		showOponentInfo ();
	}
	void showMyInfo(){
		string msg = buildMyInfo ();
		GUI.Label (new Rect (LABEL_MARGIN,LABEL_MARGIN, LABEL_WIDTH, LABEL_HEIGHT), msg);
	}
	void showOponentInfo(){
		string msg = buildOponentInfo ();
		GUI.Label (new Rect (Screen.width-LABEL_WIDTH, LABEL_MARGIN, LABEL_WIDTH, LABEL_HEIGHT), msg);
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
	private float LABEL_MARGIN=5.0f;
	private float LABEL_WIDTH=250.0f;
	private float LABEL_HEIGHT=200.0f;
}
