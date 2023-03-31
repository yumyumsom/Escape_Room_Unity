using System;
using Photon.Pun;
using Photon.Pun.Demo.Cockpit;
using Photon.Realtime;
using UnityEngine;

using UnityEngine.UI;

public class TimerTest : MonoBehaviourPunCallbacks , IPunObservable

{
    public Text timeTimer;
    public float _Sec;
    public int _Min;
    public bool flag;
    private PhotonView PV;
    private void Awake()
    {
        flag = true;
        DontDestroyOnLoad(this.gameObject);
    }
    void Update()
    {
        if (flag)
        {
            if(timeTimer==null)
                Get_TimerText();
            if (PhotonNetwork.IsMasterClient)
            {
                timer();
            }
            else
            {
                timeTimer.text = TimerForMat();
            }
        }
        else
        {
            return;
        }
        
    }

    void setLastTime()
    {
        string endgameMSG = "탈출성공!\n" + "소요시간은 "+ TimerForMat() ;
        GameObject.Find("Result_Time").GetComponent<Text>().text = endgameMSG;
    }
    void Get_TimerText()
    {
        timeTimer = GameObject.FindGameObjectWithTag("TimerText").GetComponent<Text>();
        
    }
    public string TimerForMat()
    {
        return string.Format("{0:D2}:{1:D2}", _Min, (int)_Sec);
    }
    void timer()
    {
        _Sec += Time.deltaTime;
        {
            if (timeTimer == null)
            {
                Get_TimerText();
            }

            timeTimer.text = TimerForMat();

            if ((int)_Sec > 59)
            {
                _Sec = 0;
                _Min++;
            }
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(_Sec);
            stream.SendNext(_Min);
        }
        else
        {
            this._Sec = (float)stream.ReceiveNext();
            this._Min = (int)stream.ReceiveNext();
        }
    }
}