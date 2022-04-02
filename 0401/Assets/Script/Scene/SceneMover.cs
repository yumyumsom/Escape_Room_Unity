using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//해당스크립트에서 UnityEngine.SceneManagement이 사용된 씬과 관련된 기능을 사용하기 위해 선언
using UnityEngine.SceneManagement;

public class SceneMover : MonoBehaviour
{
    void start() {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Next")
        {
            SceneManager.LoadScene("Lib"); 
        }
        
            //gameObject.transform.position = GameObject.Find("lib").transform.position;
            // AsyncOperation async;
            //  async = SceneManager.LoadSceneAsync("Stage2");

        
    }
}

