using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//해당스크립트에서 UnityEngine.SceneManagement이 사용된 씬과 관련된 기능을 사용하기 위해 선언
using UnityEngine.SceneManagement;

public class loby : MonoBehaviour
{

    public void SceneChange()
    { 
            SceneManager.LoadScene("Stage1");
        }
    
}