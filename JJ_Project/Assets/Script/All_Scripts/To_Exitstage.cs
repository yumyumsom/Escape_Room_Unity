using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class To_Exitstage : MonoBehaviour
{
    private PhotonView PV;
    public GameObject ending_panel;
    public GameObject ending_time;
    public GameObject ending_time_text;
    public GameObject helper;
    
    private void Awake()
    {
        PV = GetComponent<PhotonView>();
    }

   
   void OnMouseDown()
   {
       Inventory inven = GameObject.FindWithTag("Player").GetComponent<Inventory>();
       if (inven.checkDuck())
       {
            PV.RPC("MoveScene", RpcTarget.All);
       }
       else
       {
           helper.SetActive(true);
       }

   }

   [PunRPC]
   void MoveScene()
   {
       //GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().gameObject.SetActive(false);
       GameObject.Find("Timer").GetComponent<TimerTest>().flag = false;
       ending_panel.SetActive(true);
       ending_time.SetActive(true);
       ending_time_text.GetComponent<Text>().text = " 야호 !! " +
                                                    GameObject.Find("Timer").GetComponent<TimerTest>().TimerForMat() +
                                                    " 만에 탈출 했어!!";
   }
}
