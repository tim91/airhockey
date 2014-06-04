using UnityEngine;
using System.Collections;
using Leap;

public class KeyboardMovement : Photon.MonoBehaviour {
	public float speed=150000;
	Controller controller;
	GameObject sec;
	GameObject bumper2;
	GameObject bumper1;
	public Vector3 n=Vector3.zero;
	private Vector3 lastForce=Vector3.zero;
	float border = 100;
	float hb=50;
	// Use this for initialization
	void Start () {
		controller = new Controller ();
		sec=GameObject.Find ("SecondPos");
		bumper1 = GameObject.Find ("Bumper2");
		//bumper2=GameObject.Finde("
	}
	// Update is called once per frame
	void FixedUpdate () {
		if (PhotonNetwork.player == null || PhotonNetwork.player.customProperties["side"]==null)
						return;
		if ((int)PhotonNetwork.player.customProperties ["side"] != 1) 
						return;

		//} else {
		//Debug.Log ("viewId: "+gameObject.GetPhotonView().viewID);
			if(gameObject.GetPhotonView ().viewID == 1){

				//move();
				//return;
				float h = Input.GetAxis ("Horizontal");
				float v = Input.GetAxis ("Vertical");

				Frame frame = controller.Frame ();

				HandList hands = frame.Hands;


				Vector3 m = new Vector3 (h, 0.0f, v);
				//if (gameObject.GetPhotonView ().viewID == 3)
					//	m *= -1.0f;
				rigidbody.AddForce (m * speed * Time.deltaTime);
			}
			else{
				Vector3 m2 = new Vector3 (sec.transform.position.x, 0.0f, sec.transform.position.z);
				//Debug.Log ("m2: "+m2);
				m2*=-1.0f;
				//moveBumper(m2);
			}



				
				
		//}
	}
	void move(){
		Frame frame = controller.Frame();
		HandList hands = frame.Hands;
		Hand hand=hands[0];
		InteractionBox interactionBox = frame.InteractionBox;
		Vector lv = interactionBox.NormalizePoint(hand.PalmPosition);
		n=new Vector3((lv.x*2.0f)-1.0f,lv.y,(lv.z*2.0f)-1.0f);
		//transform.position = n;
		moveBumper (n);
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
