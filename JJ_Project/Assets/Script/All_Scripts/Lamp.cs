using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Lamp : MonoBehaviour
{

    [HideInInspector] public GameObject LampLight;
    [HideInInspector] public GameObject DomeOff;
    [HideInInspector] public GameObject DomeOn;
    private bool flag = true;
    public GameObject hint1;
    
    private PhotonView PV;
   
    
    private void Awake()
    {
        PV = GetComponent<PhotonView>();
        
    }
    void OnMouseDown()
    {
        if (flag)
        {
            LampLight.SetActive(true);
            DomeOff.SetActive(false);
            DomeOn.SetActive(true);
            
            PhotonNetwork.Instantiate(hint1.name,GameObject.Find("cardspot").transform.position, Quaternion.identity, 0);

        }
        else
        {
            LampLight.SetActive(false);
            DomeOff.SetActive(true);
            DomeOn.SetActive(false);
            hint1.SetActive(false);
        }
        flag = !flag;

    }

}