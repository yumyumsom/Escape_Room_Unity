using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Stage1GameManager : MonoBehaviourPunCallbacks
{
    public GameObject Cube;
    //public GameObject[] prefabs;
    // private List<GameObject> gameObject = new List<GameObject>();
    // private static int randomPlayer = Random.Range(1, 11);
    // private string playerprefab = "body_root_" + randomPlayer;

    void Awake()
    {
        //print("스테이지 참가수 "+ readyPlayerList.Count);
        PhotonNetwork.Instantiate("user", Cube.transform.position, Quaternion.identity);
        //Instance.name = PhotonNetwork.NickName;
    }
    
}
