using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clockcontrol : MonoBehaviour
{
    //새 오브젝트 key를 활성화하기 위해 미리 선언
    public GameObject key;

    public bool ClockState = false;

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





    }

    public bool AnswerCheck()

    {
        //(setColorscript0.cnt == 1)
        if (setColorscript0.cnt == 3 && setColorscript1.cnt == 1 &&
            setColorscript2.cnt == 2 && setColorscript3.cnt == 4)
            return true;
        else return false;
    }

    void Update()
    {
        if (AnswerCheck() == true)
        {

            GameObject item = Instantiate(key);
            item.SetActive(true);
            setColorscript0.cnt = 0;
            setColorscript1.cnt = 0;
            setColorscript2.cnt = 0;
            setColorscript3.cnt = 0;
        }
    }

}


