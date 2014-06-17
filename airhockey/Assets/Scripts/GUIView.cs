using UnityEngine;
using System.Collections;
public class GUIView : MonoBehaviour {

	public Camera camera;
	void OnGUI(){
		if (Game.isGameStarted ()) {
			showGameInfo ();
		} else {
			showWaiting ();
		}
	}
	public static void setCamera(){
		GameObject camera=GameObject.Find ("Camera");
		if (PlayerHelper.isPlayer (1)) {
			camera.transform.position = new Vector3 (1.0f,40.0f,-80.0f);
			camera.transform.localEulerAngles = new Vector3 (35.0f,0.0f,0.0f);
		} else if (PlayerHelper.isPlayer(2)){
			camera.transform.position = new Vector3 (1.0f,40.0f,80.0f);
			camera.transform.localEulerAngles = new Vector3 (35.0f,180.0f,0.0f);
		}
	}
	void Update(){
		if (!Game.isGameStarted ()) {
			camera.transform.RotateAround (new Vector3 (0, camera.transform.position.y, 0), new Vector3 (0, 1, 0), 1.0f);
		}
	}
	void showWaiting(){
		string msg = "\nConnected Players:";
		msg += buildConnectedPlayers ();
		showWindow ("Waiting for players....", msg);
	}
	string buildConnectedPlayers(){
		string msg="";
		IList list = PlayerHelper.getConnetedNames ();
		if (list.Count!=0) {
			msg+="\n";
			foreach (string name in list) {
				msg+="\t- "+name+"\n";
			}
		}

		return msg;
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

	public void showWindow(string title,string text) {
		GUI.ModalWindow (1, new Rect (Screen.width/2-LABEL_WIDTH/2, 100.0f, LABEL_WIDTH, LABEL_HEIGHT), delegate(int id) {
			GUILayout.Label (text);
		}, title);
	}
	private float LABEL_MARGIN=5.0f;
	private float LABEL_WIDTH=250.0f;
	private float LABEL_HEIGHT=200.0f;

}
