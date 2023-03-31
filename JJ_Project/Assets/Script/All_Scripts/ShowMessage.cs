using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMessage : MonoBehaviour
{
    public GameObject hint1;       
   
    public void ShowHint()
    {
        Debug.Log("클릭");
        Instantiate(hint1);
        hint1.SetActive(true);     //힌트가 보이게 하는 함수
        
    }

    public void HideHint()
    {
        hint1.SetActive(false);     //힌트를 숨기는 함수 
    }
  
   
  
}


  