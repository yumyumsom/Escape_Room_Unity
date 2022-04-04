using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class interact : MonoBehaviour

{
    public float interactDiastance = 0.2f;
    public GameObject slotItem;
    // DoorScript door;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //print("SPACE");
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, interactDiastance))
            {
                if (hit.collider.CompareTag("Door"))
                {
                    //print("SPACE+DOOR");
                    if (this.GetComponent<Inventory>().checkKey())  //인벤토리에 key가 있다면 문을 열고 해당 키(아이템)을 인벤토리에서 삭제.
                    {
                        print("KEY가 있음묘");
                        hit.collider.transform.GetComponent<DoorScript>().ChangeDoorState();

                    }
                    else // 없다면 아무일도 일어나지않는다, 또는 키가 없다고 힌트를 준다
                    {
                        print("KEY 가 없음묘");
                    }

                }
            }
        }
    }


    // void OnTriggerEnter(Collider other)


    //  if (other.gameObject.tag == "Key")

    //  Destroy(other.gameObject);
    /* Inventory inven = other.GetComponent<Inventory>();
     for(int i= 0; i <inven.slots.Count; i++){
         if (inven.slots[i].isEmpty)
         {
             Instantiate(slotItem, inven.slots[i].slotObj.transform);
             inven.slots[i].isEmpty = false;
             break;
         } 
     }*/



}

