using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lampoff : MonoBehaviour
{
    
    [HideInInspector] public GameObject LampLight;

    [HideInInspector] public GameObject DomeOff;

    [HideInInspector] public GameObject DomeOn;

    public bool TurnOn;


  
    private void OnMouseDown()
    {
    print("off");
    GameObject.Find("Lamp").transform.Find("Lampoff").gameObject.SetActive(true);
        LampLight.SetActive(false);
        DomeOff.SetActive(true);
        DomeOn.SetActive(false);
    }
}
