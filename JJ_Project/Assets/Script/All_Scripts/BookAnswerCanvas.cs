using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class BookAnswerCanvas : MonoBehaviour
{ 
    public GameObject pass;
    public GameObject key;
    public GameObject helper;
    
    
    void Start()                        
    {
        hideIPF();                    //책을 클릭하기 전에는 Inputfieㅣd가 보이지 않게하는 hideIPF함수 호출

    }
    void ShowIPF()
    {
        pass.SetActive(true);
        // Invoke("HideHint", 10); 10초 뒤 사라지게함 

        //Hint.onClick.AddListener(HideHint);
    }

    void hideIPF()                      
    {
        pass.SetActive(false);

    }
    void OnMouseDown()                  //오브젝트를 우클릭할때 실행 
    {
        GameObject.FindWithTag("MyBookName").name = this.gameObject.name.ToString();
        //print(GameObject.FindWithTag("MyBookName").name);  //클릭한 게임오브젝트의 이름을 출력
        ShowIPF();                          //Inputfield를 나타나게하는 함수 호출
    }


    // Update is called once per frame
    void Update()
    {
        
    }

     void OnMouseEnter()                            //마우스가 해당 오브젝트 위에 위치할때 실행
    {
        Vector3 vec = new Vector3(0, 0, 0.1f);      //z방향으로 0.1이동하는 백터 ,책을 꺼내는듯한 효과를 주기 위함
        transform.Translate(vec);

    }
    void OnMouseExit()                             //마우스가 해당 오브젝트 위에서 벗어날때 실행
    {
        Vector3 uvec = new Vector3(0, 0, -0.1f);  //z방향으로 -0.1이동하는 백터 , 꺼냈던 책을 다시 꽂아넣는 효과
        transform.Translate(uvec);
    }
    public void check(InputField f)
    {
       // print(GameObject.FindWithTag("MyBookName").name);
        //print(f.text);
        
        //클릭한 명이 answer일때 &&InputField에 text를 검사하여 clock일때 실행
        if (GameObject.FindWithTag("MyBookName").name == "answer" &&f.text == "운영체제") 
        {
            PhotonNetwork.Instantiate(key.name, GameObject.Find("keymake").transform.position, Quaternion.identity, 0);
            hideIPF(); // 입력받고 Ui창이 꺼짐
        }
        else
        {
            print("오답입니다.");
            helper.SetActive(true);
            hideIPF();
        }

        f.text = null;
    }
}

