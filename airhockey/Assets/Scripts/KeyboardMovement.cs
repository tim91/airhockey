using UnityEngine;
using System.Collections;
using Leap;

public class KeyboardMovement : Photon.MonoBehaviour {
	public float speed=150000;
	Controller controller;
	GameObject sec;
	GameObject bumper2;
	GameObject bumper1;
	public Vector3 n=Vector3.zero;
	private Vector3 lastForce=Vector3.zero;
	float border = 100;
	float hb=50;
	// Use this for initialization
	void Start () {
		controller = new Controller ();

	}
	// Update is called once per frame
	void FixedUpdate () {
		//return;
				float h = Input.GetAxis ("Horizontal");
				float v = Input.GetAxis ("Vertical");

				Vector3 m = new Vector3 (h, 0.0f, v);

				rigidbody.AddForce (m * speed * Time.deltaTime);
	}
}
