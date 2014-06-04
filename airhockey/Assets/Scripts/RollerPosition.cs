using UnityEngine;
using System.Collections;

public class RollerPosition : Photon.MonoBehaviour {
	
	Vector3 pos=Vector3.zero;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (photonView.isMine) {
			transform.position=Vector3.Lerp (transform.position,pos,0.0001f);
		} else {
			transform.position=Vector3.Lerp (transform.position,pos,0.0001f);
		}
	}
	public void OnPhotonSerializeView(PhotonStream stream,PhotonMessageInfo info){
		
		if (stream.isWriting) {
			stream.SendNext(transform.position);
		} else {
			pos=(Vector3)stream.ReceiveNext();
		}
	}
}
