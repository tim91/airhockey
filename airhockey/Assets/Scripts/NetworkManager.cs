using UnityEngine;
using System.Collections;
public class NetworkManager : MonoBehaviour {

	// Use this for initialization
	public Camera cam;
	GameObject sec;
	GameObject b1;
	void Start () {
		Connect ();
		sec=GameObject.Find ("SecondPos");
		b1=GameObject.Find ("Bumper2");
	}
	//polaczenie z serwerem, korzysta z ustawien PhotonServerSettings
	void Connect () {
		PhotonNetwork.ConnectUsingSettings ("0.0.1");
	}
	//wyswietla label o stanie polaczenia
	void OnGUI(){
		if(PhotonNetwork.room!=null)
			GUILayout.Label (PhotonNetwork.connectionStateDetailed.ToString ()+"  "+PhotonNetwork.room.ToString()+" "+PhotonNetwork.room.playerCount+" "+b1.transform.position);

	}

	//podlaczono do serwera
	void OnJoinedLobby(){
		Debug.Log ("OnJoinedLobby");
		PhotonNetwork.JoinRandomRoom ();
		
	}

	//nie udalo sie polaczyc do losowego pokoju
	void OnPhotonRandomJoinFailed(){
		Debug.Log ("fail join");
		PhotonNetwork.CreateRoom ("xxx");
	}
	//podlaczono do pokoju
	void OnJoinedRoom(){
		Debug.Log ("room");
		if (PhotonNetwork.room.playerCount == 1) {
			initFirstPlayer ();
		} else {
			initSecondPlayer();
		}

		//cam.transform.rotation = new Quaternion (35.0f,180.0f,0.0f);
		//GameObject o=PhotonNetwork.Instantiate ("Cube", new Vector3 (po[PhotonNetwork.room.playerCount-1], 0.5f, 0.0f), Quaternion.identity, 0);
		
		//Debug.Log ("instantiate");
		//o.AddComponent<Moving> ();
		//o.rigidbody.MovePosition (new Vector3 (2.0f,5.0f));
	}
	void initFirstPlayer(){
		ExitGames.Client.Photon.Hashtable ht = new ExitGames.Client.Photon.Hashtable ();
		ht.Add ("side", 1);
		PhotonNetwork.player.SetCustomProperties (ht);
		PhotonNetwork.OnEventCall += new PhotonNetwork.EventCallback (callback);
		//GameObject bumper=PhotonNetwork.Instantiate ("Bumper", new Vector3 (0.0f, 1.0f, -40.0f), Quaternion.identity, 0);
		//bumper.AddComponent<LeapMovement>();
		//bumper.AddComponent<KeyboardMovement>();
		//bumper.AddComponent<BumperPosition>();
		//BumperPosition bp=bumper.GetComponent<BumperPosition> ();
		//bumper.GetPhotonView ().observed = bp;
	}
	void callback(byte code,object content,int senderId){
		if (code == 55) {
			Vector3 pos=(Vector3)content;
			moveBumper(pos);
			//if(pos.x==1)
				//Debug.Log ("pos: " + content + "  " + code);
		}
	}
	private Vector3 lastForce=Vector3.zero;
	float border = 100;
	float hb=50;
	void moveBumper(Vector3 n){
		
		n.x=n.x*border-hb;
		n.x=Mathf.Max (-42,n.x);
		n.x=Mathf.Min (42,n.x);
		n.z=-n.z*border+hb;
		n.z=Mathf.Max (-42,n.z);
		n.z=Mathf.Min (42,n.z);
		
		Vector3 force=n-b1.rigidbody.position;
		
		b1.rigidbody.AddForce(lastForce*-800);
		b1.rigidbody.AddForce(force*1000);
		lastForce=force;
	}

	void initSecondPlayer(){

		ExitGames.Client.Photon.Hashtable ht = new ExitGames.Client.Photon.Hashtable ();
		ht.Add ("side", 3);
		PhotonNetwork.player.SetCustomProperties (ht);
		//GameObject sec=PhotonNetwork.Instantiate ("Bumper", new Vector3 (0.0f, 1.0f, 40.0f), Quaternion.identity, 0);
		//bumper.AddComponent<KeyboardMovement>();

		//bumper.AddComponent<BumperPosition>();
		//BumperPosition bp=bumper.GetComponent<BumperPosition> ();
		//bumper.GetPhotonView ().observed = bp;

		cam.transform.position = new Vector3 (1.0f,40.0f,-80.0f);
		cam.transform.position = new Vector3 (1.0f,40.0f,80.0f);
		cam.transform.localEulerAngles = new Vector3 (35.0f,180.0f,0.0f);
	}
}
