using UnityEngine;
using System.Collections;
using Leap;
public class ObjectPosition : Photon.MonoBehaviour {

	public float lerpFraction=0.1f;
	Vector3 realPosition=Vector3.zero;
	private int frames=0;
	private int lastFrames=1;
	private Vector3 startPos;
	private float frac=1.0f;
	private Vector3 lastPos;
	private float delta=0.0f;
	private float lastDelta=1.0f;
	// Use this for initialization
	void Start () {
		startPos=transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		frames++;
		if (PlayerHelper.isPlayer (2)) {

			if(realPosition!=Vector3.zero){
					Vector3 v = Vector3.Lerp (startPos, realPosition, frac);
					v.y=1.0f;
					Debug.Log ("Ustawilem: "+frac+" "+startPos);
					transform.position=v;
					frac+=frac;
			}

		}
	}
	public void OnPhotonSerializeView(PhotonStream stream,PhotonMessageInfo info){

		if (stream.isWriting) {
			if (PlayerHelper.isPlayer (1)) {
				stream.SendNext (transform.position);
			}
		} else {
				if (PlayerHelper.isPlayer (2)) {
					transform.position=realPosition;
					realPosition = (Vector3)stream.ReceiveNext ();
					lastFrames=frames;
					frames=0;
					startPos=new Vector3(transform.position.x,transform.position.y,transform.position.z);
					if(lastFrames!=0)
						frac=1.0f/lastFrames;
				}
		}
	}
}
