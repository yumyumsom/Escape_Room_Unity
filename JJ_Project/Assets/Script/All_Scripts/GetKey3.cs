using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class GetKey3 : MonoBehaviour

{

    public bool open = false; //처음 시작 false로 설정하고 활성화 될 때만 true로 변환되게
    public GameObject duck;
    public void ChangeDoorState()
    {
        open = !open;
    }

    void OnMouseDown()
    {
        if (open)
        {

            transform.Translate(new Vector3(0, 0, 1f));


        }
        else
        {
            transform.Translate(new Vector3(0, 0, -1f));
            PhotonNetwork.Instantiate(duck.name, GameObject.Find("greenspot").transform.position, Quaternion.identity, 0);

        }

        open = !open;
    }
}