using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Text.RegularExpressions; //text정규표현 사용을 위해 선언

public class Checkname : MonoBehaviour
{
    [Header("DisconnectPanel")] public InputField NickNameInput;

    public GameObject error;
    
    // Start is called before the first frame update

    public void Connect()
    {
        if (CheckNickname(NickNameInput.text.ToString()))
        {
           
        }
        else
        {   
            //Debug.Log("닉네임은 한글, 영어, 숫자로만 만들 수 있습니다.");
            return;
        }
        
    }

    private bool CheckNickname(string str)
    {
        if (str.Length > 0 && str.Length < 7 && Regex.IsMatch(str, "^[0-9a-zA-Z가-힣]*$"))
        {
            return true;
        }

        else
        {
            print("7자 내로 입력하시오");
            error.SetActive(true);
            return false;
        }

    }
}
