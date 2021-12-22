using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class VirtualWorldManager : MonoBehaviourPunCallbacks
{
    #region Pun Callback Methods
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log(newPlayer.NickName + " has joined the room! Player count: " + PhotonNetwork.CurrentRoom.PlayerCount);
    }
    #endregion
}
