using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseKey : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.inputString == (transform.parent.GetComponent<SlotTurn>().name + 1).ToString())
        {
            //아이템 사용 
            Debug.Log("열쇠 사용 . slot trun : " + (transform.parent.GetComponent<SlotTurn>().name + 1).ToString());
            Destroy(this.gameObject);
        }
    }
}
