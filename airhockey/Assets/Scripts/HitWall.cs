using UnityEngine;
using System.Collections;

public class HitWall : MonoBehaviour {

	void OnTriggerEnter (Collider other) {
		
		audio.Play ();
	}
}
