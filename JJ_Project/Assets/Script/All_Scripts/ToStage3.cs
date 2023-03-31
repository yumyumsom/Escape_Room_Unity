using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class ToStage3 : MonoBehaviour
{
    public DoorScript doorState;
    private PhotonView PV;
    
    private void Awake()
    {
        PV = GetComponent<PhotonView>();
    }
    void change()
    {
        
        Debug.Log("NextStage11");
        PV.RPC("MoveScene", RpcTarget.All);
    }
    

    private void Update()
    {
        if(doorState != null && doorState.open)  //doorstate상태가 open으로 된다면
            Invoke("change", 1);
    }
    [PunRPC]
    void MoveScene()
    {
        SceneManager.LoadScene("Scenes/Stage3");
    }

 
}