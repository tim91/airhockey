using UnityEngine;
using System.Collections;
public class GUIView : MonoBehaviour {

	public Camera camera;
	void OnGUI(){
		Game.getState().showGUI();
	}
	public static void setCamera(){
		GameObject camera=GameObject.Find ("Camera");
		if (PlayerHelper.isPlayer (1)) {
			camera.transform.position = new Vector3 (1.0f,40.0f,-80.0f);
			camera.transform.localEulerAngles = new Vector3 (35.0f,0.0f,0.0f);
		} else if (PlayerHelper.isPlayer(2)){
			camera.transform.position = new Vector3 (1.0f,40.0f,80.0f);
			camera.transform.localEulerAngles = new Vector3 (35.0f,180.0f,0.0f);
		}
	}
	void Update(){
		Game.getState ().modifyCamera (camera);
	}



}
