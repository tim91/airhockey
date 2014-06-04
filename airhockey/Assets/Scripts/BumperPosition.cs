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
	public float lerpFraction=0.1f;
	Vector3 realPosition=Vector3.zero;
	// Use this for initialization
	void Start () {
		controller = new Controller();
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerHelper.isPlayer (2)) {
			transform.position = Vector3.Lerp (transform.position, realPosition, lerpFraction);
		}
	}
	public void OnPhotonSerializeView(PhotonStream stream,PhotonMessageInfo info){

		if (stream.isWriting) {
			if (PlayerHelper.isPlayer (1)) {
				stream.SendNext (transform.position);
			}
		} else {
				if (PlayerHelper.isPlayer (2)) {
					realPosition = (Vector3)stream.ReceiveNext ();
				}
		}
	}
}
