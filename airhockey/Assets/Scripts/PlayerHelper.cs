using UnityEngine;
using System.Collections;

public class PlayerHelper {

	private static int[] scores = {0,0};
	public static bool playerExist(){
		if (PhotonNetwork.player == null || PhotonNetwork.player.customProperties["playerId"]==null){
			return false;
		}
		return true;
	}

	public static bool oponentExist(){
		if (PhotonNetwork.countOfPlayers!=2){
			return false;
		}
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

	public static int getMyScore(){
		return getScore (getCurrentPlayerId ());
	}
	public static string getOponentName(){
		return getOponent ().name;
	}

	public static PhotonPlayer getOponent(){
		if (isPlayer (1))
				return getPlayer (2);
		else if (isPlayer (2))
				return getPlayer (1);
		else
				return null;
	}
	public static int getOponentScore(){
		if (isPlayer (1))
				return getScore (1);
		else
				return getScore (2);
	}
	public static void score(int playerId){
		scores [playerId - 1]++;
		PhotonNetwork.RaiseEvent (56, scores [playerId - 1],true, null);
	}

	public static int getPlayerSide(int id){
		return (int)getPlayer(id).customProperties["side"];
	}

	public static PhotonPlayer getPlayer(int id){
	
		foreach (PhotonPlayer player in PhotonNetwork.playerList) {
			if((int)player.customProperties["playerId"]==id){
				return player;
			}
		}
		return null;
	}
}
