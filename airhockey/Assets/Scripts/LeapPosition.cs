using UnityEngine;
using System.Collections;
using Leap;
public class LeapPosition : MonoBehaviour {
	Controller controller;
	Vector3 pos=Vector3.zero;
	public Vector3 n=Vector3.zero;
	private Vector3 lastForce=Vector3.zero;
	float border = 100;
	float hb=50;
	// Use this for initialization
	void Start () {
		controller = new Controller();
	}
	
	// Update is called once per frame
	void Update () {
		if (PhotonNetwork.player == null || PhotonNetwork.player.customProperties["side"]==null)
			return;
		if ((int)PhotonNetwork.player.customProperties ["side"] != 1) {
			

			Frame frame = controller.Frame();
			HandList hands = frame.Hands;
			Hand hand=hands[0];
			InteractionBox interactionBox = frame.InteractionBox;
			Vector lv = interactionBox.NormalizePoint(hand.PalmPosition);
			n=new Vector3((lv.x*2.0f)-1.0f,lv.y,(lv.z*2.0f)-1.0f);
			transform.position = n;
			//Debug.Log ("raise");
			PhotonNetwork.RaiseEvent(55,n,true,null);

		}


	}
}
