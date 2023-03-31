using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;               //이미지,inputfield등의 UI를 쓰기위함
using Photon.Pun;
using UnityEngine.PlayerLoop;

public class ClickBoard : MonoBehaviour
{
    public GameObject Hint1;
    public GameObject correct;
    public GameObject wrong;
    public bool answercatch = false;
    private PhotonView PV;
    
    public  GameObject btn0;
    public  GameObject btn1;
    public  GameObject btn2;
    public GameObject btn3;

    void Start()
    {
        PV = GetComponent<PhotonView>();
        HideHint(); //게임 시작시 힌트 숨김
    }

    void ShowHint()
    {
        Hint1.SetActive(true); //힌트가 보이게 하는 함수
    }

    void HideHint()
    {
        Hint1.SetActive(false); //힌트를 숨기는 함수 
    }

    void OnMouseDown() //오브젝트를 마우스로 클릭시 실행되는 함수
    {
        ShowHint();
    }


    public void check1(InputField f) //InputField를 f로 선언
    {

        if (f.text == "clock") //InputField의 text를 검사하여 clock일때 실행
        {

            print("시계에 무언가 있는 것 같다. "); //다음 문제의 단서 제공
            HideHint(); // 입력받고 Ui창이 꺼짐
            answercatch = true;
            PV.RPC("ShowClockbutton", RpcTarget.All);
            correct.SetActive(true);
        }
        else
        {
            print("틀린답");
            HideHint();
            wrong.SetActive(true);
        }
        
        f.text = "";
    }

    [PunRPC]
    void ShowClockbutton()
    {
        btn0 = GameObject.Find("ch0btn");
        btn1 = GameObject.Find("ch01btn");
        btn2 = GameObject.Find("cm00btn");
        btn3 = GameObject.Find("cm01btn");
        
        btn0.transform.Translate(new Vector3(0, 0, 0.8f)); 
        btn1.transform.Translate(new Vector3(0, 0, 0.8f)); 
        btn2.transform.Translate(new Vector3(0, 0, 0.8f)); 
        btn3.transform.Translate(new Vector3(0, 0, 0.8f)); 
        
    }
}


