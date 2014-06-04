using UnityEngine;
using System.Collections.Generic;
using Leap;
public class LeapMovement : MonoBehaviour {
	Controller controller;
	public Renderer planeRenderer;
	void Start () {
		controller = new Controller();
		Debug.Log ("ASDSA");
		
	}
	Queue<float> px = new Queue <float>();
	Queue<float> pz = new Queue <float>();
	public int qcount=50;
	//public float speed=0.01f;
	private Vector3 target = new Vector3 (5.0f, 0.5f, 2.0f);
	public float speed=50;
	private Vector3 lastForce=Vector3.zero;
	// Update is called once per frame
	void Update () {

		if ( Input.GetMouseButtonDown(0))
		{
			Debug.Log("click");
			//float planeWidth =planeRenderer.bounds.size.x;
			//float wallWidth =planeRenderer.bounds.size.x;
			//Debug.Log(planeWidth);
			//Vector3 force=new Vector3(0.0f,0.0f,1000.0f);
			//rigidbody.AddForce(force*100);
			//rigidbody.MovePosition(new Vector3(rigidbody.position.x,rigidbody.position.y,3.0f));
			return;
		}
		Frame frame = controller.Frame();
		//Debug.Log("update");
		InteractionBox interactionBox = frame.InteractionBox;
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		Vector3 m = new Vector3 (h, 0.0f,v);
		float border = 100;
		float hb = border / 2;
		HandList hands = frame.Hands;
		foreach(Hand ha in hands ){
			//Debug.Log("handFound");
			float x=ha.PalmPosition.x;
			float z=ha.PalmPosition.z;
		    
			Vector n = interactionBox.NormalizePoint(ha.PalmPosition);	
			//Debug.Log("handPos: "+n);
			//n.x=n.x*0.6f+0.2f;
			n.x=n.x*border-hb;
			n.x=Mathf.Max (-42,n.x);
			n.x=Mathf.Min (42,n.x);
			n.z=-n.z*border+hb;
			n.z=Mathf.Max (-42,n.z);
			n.z=Mathf.Min (42,n.z);
			add(px,n.x);
			add(pz,n.z);
			Vector3 p=new Vector3(avg(px),rigidbody.position.y,avg(pz));
			//Debug.Log("AVGhandPos: "+p);

			//Debug.Log ("rb "+rigidbody.position);
			//Debug.Log ("p "+p);

			//Vector3 d=rigidbody.position-p;
			//if(d.x<0.1f && d.z<0.1f)
			//	continue;
			//Vector3 d=p-rigidbody.position;
		//	d=d.normalized;
			Vector3 force=p-rigidbody.position;
			float r=45.0f;
			//Debug.Log(force);

			if(Mathf.Abs(force.x)<r && Mathf.Abs(force.z)<r)
			{
				//rigidbody.velocity = Vector3.zero;
				//return;
			//	rigidbody.angularVelocity = Vector3.zero; 
				//rigidbody.AddForce(force*1);
			}
			else{
					
				}
			//rigidbody.velocity =force;//
			rigidbody.AddForce(lastForce*-800);
			rigidbody.AddForce(force*1000);
			lastForce=force;
			//force.x=force.x*Mathf.Abs (force.x);
			//force.z=force.z*Mathf.Abs(force.z);
			//
			//rigidbody.isKinematic = true;
			//rigidbody.velocity = Vector3.zero;
			//rigidbody.angularVelocity = Vector3.zero; 
			//rigidbody.isKinematic = false;
			
			//yield WaitForSeconds(1);

			//else{
			//	rigidbody.AddForce(force*5);
			//}

		}

		//Vector3 x = (target - m);
	//	if (x.x <= 1.0f && x.z <= 1.0f)
			//return;
		//Debug.Log (x);
		//Vector3 v= new Vector3(rigidbody.position.x,rigidbody.position.y,rigidbody.position.z);
		//v.z = v.z + 4f;
		//Debug.Log ("vector: "+v.z);
		//rigidbody.MovePosition (rigidbody.position+new Vector3 (0.0f, 0.0f,1.0f));// x*Time.deltaTime);
		//rigidbody.AddForce (m * speed * Time.deltaTime);
		//rigidbody.MovePosition (m * Time.deltaTime);
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
