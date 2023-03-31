using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class clockcontrol : MonoBehaviour
{
    //새 오브젝트 key를 활성화하기 위해 미리 선언
    public GameObject key;

    public bool ClockState = false;
    setColor setColorscript0;
    setColor setColorscript1;
    setColor setColorscript2;
    setColor setColorscript3;
    private PhotonView PV;


    private void Awake()
    {
        PV = GetComponent<PhotonView>();
        setColorscript0 = GameObject.Find("ch0btn").GetComponent<setColor>();
        setColorscript1 = GameObject.Find("ch01btn").GetComponent<setColor>();
        setColorscript2 = GameObject.Find("cm00btn").GetComponent<setColor>();
        setColorscript3 = GameObject.Find("cm01btn").GetComponent<setColor>();
    }

    public bool AnswerCheck()

    {
        if (setColorscript0.cnt == 3 && setColorscript1.cnt == 1 && 
            setColorscript2.cnt == 2 && setColorscript3.cnt == 4)
            return true;
            return false;
    }

    void Update()
    {
       
        if (AnswerCheck() == true)
        {
            PhotonNetwork.Instantiate(key.name, key.transform.position, Quaternion.identity, 0);
           
            PV.RPC("Init_Clock_Value", RpcTarget.All);
        }
        
    }

    [PunRPC]
    void Init_Clock_Value()
    {
        setColorscript0.cnt = 0;
        setColorscript1.cnt = 0;
        setColorscript2.cnt = 0;
        setColorscript3.cnt = 0;
        GameObject.Find("ch0btn").SetActive(false);
        GameObject.Find("ch01btn").SetActive(false);
        GameObject.Find("cm00btn").SetActive(false);
        GameObject.Find("cm01btn").SetActive(false);
    }
    
 
}
   

