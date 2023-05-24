using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
public class yonet : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("servera girildi");
        PhotonNetwork.JoinLobby();
    }
    public override void OnJoinedLobby()
    {
        Debug.Log("lobiye girildi");
        PhotonNetwork.JoinOrCreateRoom("oda",new RoomOptions { MaxPlayers =2,IsOpen=true,IsVisible=true},TypedLobby.Default);
        
       // PhotonNetwork.JoinRandomRoom();
    }
    public override void OnJoinedRoom()
    {
        Debug.Log("odaya girildi");
        GameObject nesne = PhotonNetwork.Instantiate("kup",Vector3.zero,Quaternion.identity,0,null);
        nesne.GetComponent<PhotonView>().Owner.NickName = "Secgel";
        
    }
    public override void OnLeftLobby()
    {
        Debug.Log("lobiden çýkýldý");
    }
    public override void OnLeftRoom()
    {
        Debug.Log("odadan çýkýldý");
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("Hata : Odaya Girilemedi..!");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Hata : Herhangi Bir Odaya Girilemedi..!");

    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Hata : Oda Kurulamadý..!");
    }
}
