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
            print("SPACE");
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, interactDiastance))
            {
                if (hit.collider.CompareTag("Door"))
                {
                    print("SPACE+DOOR");
                    hit.collider.transform.GetComponent<DoorScript>().ChangeDoorState();
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

   