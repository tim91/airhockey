using UnityEngine;
using System.Collections;

public class GUIUtils {
	
	public static void showWindow(string title,string text) {
		GUI.ModalWindow (1, new Rect (100, 100, 200, 200), delegate(int id) {
			GUILayout.Label (text);
		}, title);
	}
}
