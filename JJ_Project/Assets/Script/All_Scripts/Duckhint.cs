using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duckhint : MonoBehaviour
{
    public bool open = true;
    public void ChangeBedState() { open = !open; }
    public GameObject hint;
    void OnMouseDown()
    {
        if (open)
        {
            GameObject.Find("Duck_hint").transform.Translate(new Vector3(0, -1f, 0)); 
            //GameObject item = Instantiate(hint);
         //   item.SetActive(true);

        }else
        {
           hint.transform.Translate(new Vector3(0, 1f, 0));
   
        }
        open = !open;
    }
}