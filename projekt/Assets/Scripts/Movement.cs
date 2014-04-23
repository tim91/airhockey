using UnityEngine;
using System.Collections.Generic;
using Leap;
public class Movement : MonoBehaviour {
	Controller controller;
	void Start () {
		controller = new Controller();
		Debug.Log ("Leap started");
		
	}
	Queue<float> px = new Queue <float>();
	Queue<float> pz = new Queue <float>();
	public int qcount=3;

	void Update () {
		Frame frame = controller.Frame();
		InteractionBox interactionBox = frame.InteractionBox;

		float borderx= 25;
		float borderz= 35;
		float left = 204;
		float right = 229;
		float top = 79;
		float bottom = 44;
		HandList hands = frame.Hands;
		foreach(Hand ha in hands ){
			float x=ha.PalmPosition.x;
			float z=ha.PalmPosition.z;

			Vector n = interactionBox.NormalizePoint(ha.PalmPosition);	

			n.x=n.x*borderx+left;
			n.x=Mathf.Max (204,n.x);
			n.x=Mathf.Min (229,n.x);
			n.z=(1-n.z)*borderz+bottom;
			n.z=Mathf.Max (44,n.z);
			n.z=Mathf.Min (79,n.z);
			add(px,n.x);
			add(pz,n.z);
			Vector3 p=new Vector3(avg(px),rigidbody.position.y,avg(pz));
			rigidbody.MovePosition (p);
		}

	}
	float avg(Queue<float> q){
		float sum = 0;
		int c = 0;
		foreach (float x in q) {
			sum+=x;
			c++;
		}
		if (c == 0)
						return 0;
		return sum / c;
	}
	void add(Queue<float> q,float x){
		q.Enqueue(x);
		if (q.Count > qcount)
						q.Dequeue ();
	}
}
