using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public GameObject slotItem;
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            Inventory inven = other.GetComponent<Inventory>();
            for (int i = 0; i < inven.slots.Count; i++)
            {
                if (inven.slots[i].isEmpty)
                {
                    Instantiate(slotItem, inven.slots[i].slotObj.transform);
                    inven.slots[i].isEmpty = false;

                    //  Debug.Log("ㅇl거");

                    GameObject.Find(("key_key(Clone)")).SetActive(false);
                    break;
                }
            }

        }
    }
}
