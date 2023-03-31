using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalGameManager : MonoBehaviour
{

    public GameObject[] players;
    public GameObject[] whiches;
   
    

    /*void Awake()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < players.Length; i++)
        {
            whiches[i]=  transform.GetChild(i+1).gameObject;
            whiches[i].transform.position = players[i].transform.position;
            
        }
        //whiches =  GetComponent<>();

        //whiches = Resources.LoadAll<GameObject>("Position");


    }*/
    
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
       
        whiches = GameObject.Find("PlayerWhich").GetComponentsInChildren<GameObject>();
       
    }

    void Update()
    {
        for (int i = 0; i < 4; i++)
        {
           
            players[i].transform.position = whiches[i].transform.position;
            players[i].transform.localScale = this.transform.localScale;
            players[i].transform.rotation = this.transform.rotation;
           
            
        }
    }
}
