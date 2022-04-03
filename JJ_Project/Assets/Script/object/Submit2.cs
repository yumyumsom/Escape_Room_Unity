using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Submit2 : MonoBehaviour
{
    public static int key = 0;
    public GameObject pass; // 게임오브젝트로 받기

   void start()
    {
     //   Debug.Log("start");
        pass.SetActive(false);
    }

    public void check(InputField f) //InputField를 f로 선언
    {
      
        {
           
            {
                if (true && f.text == "clock") //책의 tag가 answer일때 &&InputField에 text를 검사하여 clock일때 실행
                {

                    print("지금 우리학교는 ");
                    pass.SetActive(false); // 입력받고 Ui창이 꺼짐

                    //break;s
                }
                else
                {
                    print("틀린답");
                    pass.SetActive(false);
                }
                //pass.SetActive(false);

            }
        }
    }
}
 