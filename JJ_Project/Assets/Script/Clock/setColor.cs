using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setColor : MonoBehaviour
{
    public int cnt = 0;
    public int maxNum = 10;//시계 최대 숫자
    //public GameObject zeroBtn;
    public Transform zeroBtn; //자식부모관계 -자식정보 줍줍
    public GameObject[] zeroBtnChild; //오브젝트 속성
    // Start is called before the first frame update
    public int[,] shape = { { 1, 1, 1, 0, 1, 1, 1 },
                            { 0, 0, 1, 0, 0, 0, 1 },
                            { 0, 1, 1, 1, 1, 1, 0 },
                            { 0, 1, 1, 1, 0, 1, 1 },
                            { 1, 0, 1, 1, 0, 0, 1 },
                            { 1, 1, 0, 1, 0, 1, 1 },
                            { 1, 0, 0, 1, 1, 1, 1 },
                            { 1, 1, 1, 0, 0, 0, 1 },
                            { 1, 1, 1, 1, 1, 1, 1 },
                            { 1, 1, 1, 1, 0, 0, 1 } };
    void Start()
    {
        zeroBtnChild = new GameObject[zeroBtn.childCount];
        for (int i = 0; i < zeroBtn.childCount; i++) //시작하면 
        {
            zeroBtnChild[i] = zeroBtn.GetChild(i).gameObject; //버튼에 있는 차일드를 배열에 할당
        }
    }

    // Update is called once per frame
    void Update()
    {
        //print("CHOBTN");
    }
    void OnMouseDown()
    {
       initColor();
        cnt = cnt % maxNum;
        for(int i =0; i< zeroBtnChild.Length; i++)
         {
             if(shape[cnt, i] == 1)
             {
                 zeroBtnChild[i].gameObject.GetComponent<Renderer>().material.color = Color.red;
             }
         }
        cnt++;

    }
    void initColor()
    {
        foreach (GameObject g in zeroBtnChild)
        {
            g.gameObject.GetComponent<Renderer>().material.color = Color.black;
        }
    }
}
