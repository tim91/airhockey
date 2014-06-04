using UnityEngine;
using System.Collections;

public class BumperMover  {

	private GameObject bumper;
	private float side;
	public BumperMover(GameObject bumper,float side){
		this.bumper = bumper;
		this.side = side;
	}
	public void positionChanged(byte code,object content,int senderId){
		if (code == 55) {
			Vector3 pos=(Vector3)content;
			moveBumper(pos);
		}
	}

	private Vector3 lastForce=Vector3.zero;
	float border = 100;
	float hb=50;
	
	void moveBumper(Vector3 n){

		n *= side;
		n.x=n.x*border-hb;
		n.x=Mathf.Max (-42,n.x);
		n.x=Mathf.Min (42,n.x);
		n.z=-n.z*border+hb;
		n.z=Mathf.Max (-42,n.z);
		n.z=Mathf.Min (42,n.z);
		
		Vector3 force=n-bumper.rigidbody.position;
		
		bumper.rigidbody.AddForce(lastForce*-700);
		bumper.rigidbody.AddForce(force*800);
		lastForce=force;
	}
}
