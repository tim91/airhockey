using UnityEngine;
using System.Collections;

public class ScoreTrigger : MonoBehaviour {

	public int playerId;
	GameObject bumper1;
	GameObject bumper2;

	void Start(){
		bumper1 = GameObject.Find ("Bumper1");
		bumper2 = GameObject.Find ("Bumper2");
	}
	// Use this for initialization
	void OnTriggerEnter (Collider other) {
		Debug.Log ("score");
		bumper1.rigidbody.velocity = Vector3.zero;
		bumper1.rigidbody.angularVelocity = Vector3.zero;
		bumper2.rigidbody.velocity = Vector3.zero;
		bumper2.rigidbody.angularVelocity = Vector3.zero;
		other.rigidbody.velocity = Vector3.zero;
		other.rigidbody.angularVelocity = Vector3.zero;

		bumper1.transform.position=new Vector3(0.0f,bumper1.transform.position.y,-40.0f);
		//bumper2.transform.position=new Vector3(0.0f,bumper2.transform.position.y,40.0f);

		if (PlayerHelper.isPlayer (1)) {
			PlayerHelper.score(playerId);
			float z=20.0f*-1;
			other.transform.position=new Vector3(0.0f,other.transform.position.y,z);

		}
	}

}
