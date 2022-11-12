using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public InputField NickNameInput;
    void Awake()
    {
        Screen.SetResolution(1920, 1080, false);
        PhotonNetwork.SendRate = 60;
        PhotonNetwork.SerializationRate = 30;
    }
    public void Connect() => PhotonNetwork.ConnectUsingSettings();

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions {MaxPlayers = 6}, null);
    }
    public override void OnJoinedRoom()
    {
        LoadingSceneController.LoadScene("Ohnozo'sServerTestRoom");
        spawn();
    }
    public void spawn()
    {
        PhotonNetwork.Instantiate("PLAYER", new Vector3(10,3,10), Quaternion.identity);
        //Debug.Log("spawn");
    }
}
