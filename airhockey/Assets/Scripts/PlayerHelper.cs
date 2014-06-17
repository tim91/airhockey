using UnityEngine;
using System.Collections;

public class PlayerHelper {

	public static int[] scores = {0,0};
	private static string defaultName="<Unknown>";
	public static string[] names={defaultName,defaultName};
	public static bool playerExist(){
		if (PhotonNetwork.player == null || PhotonNetwork.player.customProperties["playerId"]==null){
			return false;
		}
		return true;
	}

	public static bool oponentExist(){
		return true;
	}
	public static bool isPlayer(int id){
		if (PhotonNetwork.player == null || PhotonNetwork.player.customProperties["playerId"]==null){
			if(id==1)
				return true;
			return false;
		}
		if ((int)PhotonNetwork.player.customProperties ["playerId"] == id) 
			return true;
		return false;
	}

	public static int getCurrentPlayerId(){
		return (int)PhotonNetwork.player.customProperties ["playerId"];
	}
	public static int getScore(int playerId){
		return scores[playerId-1];
	}

	public static int getOponentId(){
		if (isPlayer (1))
			return 2;
		return 1;
	}

	public static int getMyScore(){
		return getScore (getCurrentPlayerId ());
	}
	public static string getOponentName(){
		if (isPlayer (1))
			return names[1];
		return names[0];
	}


	public static int getOponentScore(){
		if (isPlayer (1))
			return scores[1];
		return scores[0];
	}
	public static void score(int playerId){
		scores [playerId - 1]++;
		Debug.Log ("Player: " + playerId + " send score: "+scores [playerId - 1]+". Current: "+getCurrentPlayerId());
		PhotonNetwork.RaiseEvent (56,scores,true, null);
	}

	public static IList getConnetedNames(){
		IList list = new ArrayList ();
		foreach (string name in names) {
			if(!name.Equals(defaultName)){
				list.Add (name);
			}
		}

		return list;
	}


	//public static int getPlayerSide(int id){
	//	return (int)getPlayer(id).customProperties["side"];
	//}
	
}
