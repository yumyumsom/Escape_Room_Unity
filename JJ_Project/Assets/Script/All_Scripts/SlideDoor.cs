using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class SlideDoor : MonoBehaviour

{

    public bool open = false; //처음 시작 false로 설정하고 활성화 될 때만 true로 변환되게
    public GameObject redduck;
    public void ChangeDoorState()
    {
        open = !open;
    }

    void OnMouseDown()
    {
        if (open)
        {
            transform.Translate(new Vector3(0, 1f, 0));
           

            return;
        }
        else
        {
            transform.Translate(new Vector3(0, -1f, 0)); 
            if (this.gameObject.name == "Drawer2")
            {
                PhotonNetwork.Instantiate(redduck.name,GameObject.Find("redspot").transform.position, Quaternion.identity, 0);
            }
        }

        open = !open;
    }
}

