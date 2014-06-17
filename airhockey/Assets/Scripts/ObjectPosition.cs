using UnityEngine;
using System.Collections;
using Leap;
public class ObjectPosition : Photon.MonoBehaviour {

	public float lerpFraction=0.1f;
	Vector3 realPosition=Vector3.zero;
	// Use this for initialization
	void Start () {
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
