using UnityEngine;
using System.Collections;
using Leap;
public class BumperPosition : Photon.MonoBehaviour {
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
		Frame frame = controller.Frame();
		HandList hands = frame.Hands;
		Hand hand=hands[0];
		InteractionBox interactionBox = frame.InteractionBox;
		Vector lv = interactionBox.NormalizePoint(hand.PalmPosition);
		n=new Vector3(lv.x,lv.y,lv.z);
		moveBumper(n);
	}
	public void OnPhotonSerializeView(PhotonStream stream,PhotonMessageInfo info){

		Debug.Log ("serialize");
		if (stream.isWriting) {
				stream.SendNext(n);
		} else {
			n=(Vector3)stream.ReceiveNext();
			moveBumper(n);
		}
	}

	void moveBumper(Vector3 n){

		n.x=n.x*border-hb;
		n.x=Mathf.Max (-42,n.x);
		n.x=Mathf.Min (42,n.x);
		n.z=-n.z*border+hb;
		n.z=Mathf.Max (-42,n.z);
		n.z=Mathf.Min (42,n.z);

		Vector3 force=n-rigidbody.position;

		rigidbody.AddForce(lastForce*-800);
		rigidbody.AddForce(force*1000);
		lastForce=force;
	}
}
