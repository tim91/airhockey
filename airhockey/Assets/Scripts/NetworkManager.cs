using UnityEngine;
using System.Collections;
public class NetworkManager : MonoBehaviour {
	
	public Camera cam;
	GameObject bumper1;
	GameObject bumper2;

	void Start () {
		Connect ();
		bumper1=GameObject.Find ("Bumper1");
		bumper2=GameObject.Find ("Bumper2");
	}
	//polaczenie z serwerem, korzysta z ustawien PhotonServerSettings
	void Connect () {
		PhotonNetwork.ConnectUsingSettings ("0.0.1");
	}
	//podlaczono do serwera
	void OnJoinedLobby(){
		Debug.Log ("OnJoinedLobby");
		PhotonNetwork.JoinRandomRoom ();
	}

	//nie udalo sie polaczyc do losowego pokoju
	void OnPhotonRandomJoinFailed(){
		Debug.Log ("Fail join random room");
		PhotonNetwork.CreateRoom ("Airhockey");
	}

	//podlaczono do pokoju
	void OnJoinedRoom(){
		Debug.Log ("Room joined");
		if (PhotonNetwork.room.playerCount == 1) {
			initFirstPlayer ();
		} else {
			initSecondPlayer();
		}
	}
	void initFirstPlayer(){
		ExitGames.Client.Photon.Hashtable ht = new ExitGames.Client.Photon.Hashtable ();
		ht.Add ("side", 1.0f);
		ht.Add ("playerId", 1);
		ht.Add ("score", 0);
		PlayerHelper.names [0] = "Player1";
		PhotonNetwork.player.SetCustomProperties (ht);
		PhotonNetwork.playerName = "Player1";
		BumperMover bumperMover = new BumperMover (bumper2,-1.0f);
		PhotonNetwork.OnEventCall += new PhotonNetwork.EventCallback ( bumperMover.positionChanged);
	}

	void initSecondPlayer(){
		ExitGames.Client.Photon.Hashtable ht = new ExitGames.Client.Photon.Hashtable ();
		ht.Add ("side", -1.0f);
		ht.Add ("playerId", 2);
		ht.Add ("score", 0);
		PlayerHelper.names [1] = "Player2";
		PhotonNetwork.player.SetCustomProperties (ht);
		PhotonNetwork.playerName = "Player2";
		reverseCamera ();

		PhotonNetwork.OnEventCall += new PhotonNetwork.EventCallback ( scoreChanged);
		PhotonNetwork.RaiseEvent (57, PhotonNetwork.playerName,true, null);
	}

	public void scoreChanged(byte code,object content,int senderId){
		Debug.Log ("Recive event: "+code+". Current: "+PlayerHelper.getCurrentPlayerId());
		 if (code == 56) {
			PlayerHelper.setScore ((int[])content);	
		} else if (code == 57) {
			PlayerHelper.names[0]=(string)content;
			Game.startGame ();
		}
	}
	void reverseCamera(){
		cam.transform.position = new Vector3 (1.0f,40.0f,80.0f);
		cam.transform.localEulerAngles = new Vector3 (35.0f,180.0f,0.0f);
	}
}
