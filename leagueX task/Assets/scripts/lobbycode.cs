using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class lobbycode : MonoBehaviourPunCallbacks
{
    public InputField create;
    public InputField join;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void createroom()
    {
        PhotonNetwork.CreateRoom(create.text);
    }

    public void joinroom()
    {
        PhotonNetwork.JoinRoom(join.text);
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("MainScene");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void leave()
    {
        SceneManager.LoadScene("lobby");
        PhotonNetwork.LeaveRoom();
    }

}
