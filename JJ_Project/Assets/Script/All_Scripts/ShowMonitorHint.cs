using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMonitorHint : MonoBehaviour
{//책을 클릭했을때 나타날 inputfield를 매칭하기위한 게임오브젝트선언
    public GameObject pass;               

    void Start()                        
    {//책을 클릭하기 전에는 Inputfieㅣd가 보이지 않게하는 hideIPF함수 호출
        hideIPF();                    

    }
    void ShowIPF()
    {
        pass.SetActive(true);
    
    }
    void hideIPF()                      
    {
        pass.SetActive(false);

    }
    //오브젝트를 우클릭할때 실행 
    void OnMouseDown()                  
    {
        //Inputfield를 나타나게하는 함수 호출
        ShowIPF();      
    }

}
