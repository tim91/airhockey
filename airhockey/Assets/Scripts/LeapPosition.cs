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
	GameObject bumper1;
	BumperMover bumperMover;
	// Use this for initialization
	void Start () {
		controller = new Controller();

	}
	BumperMover getBumperMover(){
		if (bumperMover == null) {
			if (PlayerHelper.isPlayer (1)) {
				bumper1=GameObject.Find ("Bumper1");
				bumperMover=new BumperMover(bumper1,1.0f);
			}
		}
		return bumperMover;
	}
	// Update is called once per frame
	void Update () {

		Frame frame = controller.Frame ();
		HandList hands = frame.Hands;
		Hand hand = hands [0];
		InteractionBox interactionBox = frame.InteractionBox;
		Vector lv = interactionBox.NormalizePoint (hand.PalmPosition);
		n = new Vector3 ((lv.x * 2.0f) - 1.0f, lv.y, (lv.z * 2.0f) - 1.0f);

		if (PlayerHelper.isPlayer (2)) {
			PhotonNetwork.RaiseEvent (55, n, true, null);

		} else if (PlayerHelper.isPlayer (1))  {

			getBumperMover().positionChanged(55,n,0);
		}


	}
}
