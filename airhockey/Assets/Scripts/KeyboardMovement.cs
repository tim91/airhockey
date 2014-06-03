using UnityEngine;
using System.Collections;
using Leap;

public class KeyboardMovement : MonoBehaviour {
	public float speed=150000;
	Controller controller;
	// Use this for initialization
	void Start () {
		controller = new Controller ();
		
	}
	// Update is called once per frame
	void FixedUpdate () {
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");

		Frame frame = controller.Frame();

		HandList hands = frame.Hands;


		Vector3 m = new Vector3 (h, 0.0f, v);

		rigidbody.AddForce (m * speed * Time.deltaTime);
	}
}
