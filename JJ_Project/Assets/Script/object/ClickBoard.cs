using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;               //이미지,inputfield등의 UI를 쓰기위함

public class ClickBoard : MonoBehaviour
{
    public GameObject Hint1;        //칠판을 클릭했을때 나타낼 힌트 이미지를 설정할 오브젝트선언
    // Start is called before the first frame update
    void Start()
    {
        HideHint();             //게임 시작시 힌트 숨김
        // btnHint.onClick.AddListener(ShowHint);

    }
     void ShowHint()
    {
        Hint1.SetActive(true);     //힌트가 보이게 하는 함수
        // Invoke("HideHint", 10);

        //Hint.onClick.AddListener(HideHint);
    }

    void HideHint()
    {
        Hint1.SetActive(false);     //힌트를 숨기는 함수 
    }
  
    void OnMouseDown()              //오브젝트를 마우스로 클릭시 실행되는 함수
    {   
        ShowHint();
    }

  
    public void check1(InputField f) //InputField를 f로 선언
    {
     
            if (f.text == "clock") //InputField의 text를 검사하여 clock일때 실행
            {

                print("지금 우리학교는 "); //다음 문제의 단서 제공
                HideHint(); // 입력받고 Ui창이 꺼짐

            }
            else
            {
                print("틀린답");
                HideHint();
            }          
    }
}

