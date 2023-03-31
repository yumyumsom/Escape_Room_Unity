using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage2manager : MonoBehaviour
{
    
    
    private GameObject player;

    private PhotonView PV;
    
    private void Awake()
    {
       // PV = GetComponent<PhotonView>();
    }
    // Start is called before the first frame update
    void Update()
    {
        //PV.RPC("Setscale", RpcTarget.All);
    }
    [PunRPC]
    void Setscale()
    {
       // player= GameObject.FindGameObjectWithTag("Player");
        //player.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f); 
    }

}
