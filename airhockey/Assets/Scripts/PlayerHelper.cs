using UnityEngine;
using System.Collections;

public class PlayerHelper {

	public static bool isPlayer(int id){
		if (PhotonNetwork.player == null || PhotonNetwork.player.customProperties["playerId"]==null)
			return false;
		if ((int)PhotonNetwork.player.customProperties ["playerId"] == id) 
			return true;
		return false;
	}
}
