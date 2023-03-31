using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class NextStage : MonoBehaviour
{
    public DoorScript doorState;
    private PhotonView PV;
    
    private void Awake()
    {
        PV = GetComponent<PhotonView>();
    }
    void change()
    {
        
        Debug.Log("NextStage");
        PV.RPC("MoveScene", RpcTarget.All);
    }
    

    private void Update()
    {
        if(doorState != null && doorState.open)  //doorstate상태가 open으로 된다면
            Invoke("change", 1); //시간지연함수 사용해서 2초뒤에 change호출
    }
    [PunRPC]
    void MoveScene()
    {
        SceneManager.LoadScene("Scenes/Stage2");
        
    }

 
}
