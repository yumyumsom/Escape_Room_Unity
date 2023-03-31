using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
public class interact : MonoBehaviour
//Door script
{
    public float interactDiastance = 0.2f;
    private PhotonView PV;
    private void Awake()
    {

        PV = GetComponent<PhotonView>();
    }
    void Update()
    {
        if (!PV.IsMine)
            return;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //print("SPACE");
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, interactDiastance))
            {
                if (hit.collider.CompareTag("Door"))
                {
                    if (this.GetComponent<Inventory>().checkKey()) 
                    {
                        print("KEY가 있음");
                        hit.collider.transform.GetComponent<DoorScript>().ChangeDoorState();
                    }
                    else 
                    {
                        print("KEY 가 없음");
                    }

                }
            }
        }
    }
}

