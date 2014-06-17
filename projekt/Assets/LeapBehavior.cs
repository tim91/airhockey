using UnityEngine;
using System.Collections;
using Leap;

public class LeapBehavior : MonoBehaviour {
	Controller controller;
	public Transform bumper;
	// Use this for initialization
	void Start () {
		controller = new Controller();
		Debug.Log ("ASDSA");

	}
	int speed=3;
	// Update is called once per frame
	void Update () {
		/*Frame frame = controller.Frame();
		HandList hands = frame.Hands;
		int width=UnityEngine.Screen.width;
		int height = UnityEngine.Screen.height;
		double fw = width / 200;
		int left = 203;
		int right = 228;
		int top = 58;
		int bottom = 42;
		int vrange = top - bottom;
		int range = right - left;
		float u=(float) range / 300;
		float vu=(float)vrange/200;
		foreach(Hand h in hands ){
			float x=h.PalmPosition.x+150;
			float z=h.PalmPosition.z*(-1)+150;
			x=x*u;
			z=z*vu;
			z+=bottom;
			x+=left;
			Debug.Log ("["+x+" , "+h.PalmPosition.z+" ]");
			bumper.position=new Vector3(x,1,z);
		}
		FingerList fingers = frame.Fingers;
		Debug.Log (fingers.Count);
		*/
		bumper.eulerAngles=new Vector3(0,0,0);
		
		if (Input.GetKey("right")) {
			Vector3 movingVector = Vector3.right;
			//movingVector.y=100;
			bumper.Translate(Vector3.right * speed* Time.deltaTime);
		}
		if (Input.GetKey("left")) {
			Vector3 movingVector = Vector3.left;
			//movingVector.y=100;
			bumper.Translate(movingVector * speed* Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.UpArrow)) {
			Vector3 movingVector = Vector3.forward;
			//movingVector.y=100;
			bumper.Translate(movingVector * speed* Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.DownArrow)) {
			Vector3 movingVector = -Vector3.forward;
			//movingVector.y=100;
			bumper.Translate(movingVector * speed* Time.deltaTime);
		}

	}
}
