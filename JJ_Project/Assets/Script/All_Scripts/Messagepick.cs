using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.Purchasing;

public class Messagepick : MonoBehaviour
{
    public GameObject hint1;
    //public GameObject hint2;
    private PhotonView PV;
    public bool isclick = false;
    private void Awake()
    {
        PV = GetComponent<PhotonView>();
        
    }
    
    private void OnMouseDown()
    {
        if (isclick == true) return;
        
        PhotonNetwork.Instantiate(hint1.name, hint1.transform.position, Quaternion.identity, 0);
        print("아이템이 나타남");
        isclick = true;
    }
}