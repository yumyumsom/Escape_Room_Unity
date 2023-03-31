using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;               //이미지,inputfield등의 UI를 쓰기위함

public class TvQuiz : MonoBehaviour
{
    public GameObject quiz;
    public GameObject key;
    private PhotonView PV;
   
    
    private void Awake()
    {
        PV = GetComponent<PhotonView>();
        
    }
    void Start()
    {
        Hidequiz();            

    }
     void Showquiz()
    {
        quiz.SetActive(true);     
    }

    void Hidequiz()
    {
        quiz.SetActive(false);     
    }
  
    void OnMouseDown()              
    {   
        Showquiz();
    }

  
    public void check(InputField f) //InputField를 f로 선언
    {
        f.text = f.text.ToUpper();  //소문자 대문자 모두 정답으로 하기 위해 설정
            if (f.text == "GIFT") //InputField의 text를 검사하여 정답 확인
            {                
                Hidequiz(); // 입력받고 Ui창이 꺼짐
                print("정답입니다 "); //다음 문제의 단서 제공
                
                PhotonNetwork.Instantiate(key.name, GameObject.Find("sofaspot").transform.position, Quaternion.identity, 0);
              
            }
            else
            {
                print("틀린답");
            }          
    }
}

