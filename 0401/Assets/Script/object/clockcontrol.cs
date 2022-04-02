using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clockcontrol : MonoBehaviour
{
    //새 오브젝트 key를 활성화하기 위해 미리 선언
    public GameObject key;

    setColor setColorscript0;
    setColor setColorscript1;
    setColor setColorscript2;
    setColor setColorscript3;


    
    private void Awake()
     {
        setColorscript0 = GameObject.Find("ch0btn").GetComponent<setColor>();
        setColorscript1 = GameObject.Find("ch01btn").GetComponent<setColor>();
        setColorscript2 = GameObject.Find("cm00btn").GetComponent<setColor>();
        setColorscript3 = GameObject.Find("cm01btn").GetComponent<setColor>();

       key.SetActive(false);
      
    }



   

    void Update()
    { 
        {

            if (setColorscript0.cnt == 3 && setColorscript1.cnt == 1 && 
                setColorscript2.cnt == 2 && setColorscript3.cnt == 4)
            {
                   //새 오브젝트 생성(열쇠)
                key.SetActive(true);
           


            }
        
        

        }
       

    }
}
