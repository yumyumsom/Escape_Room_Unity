using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class itemclickup : MonoBehaviour
{
       public GameObject ItemPrefab;
       private PhotonView PV;
       private void Awake()
       {
           PV = GetComponent<PhotonView>();
       }
       void OnMouseDown()
       {
           print("클릭   "); 
           PV.RPC("All_Set_Item_Inventory", RpcTarget.All);
           
       }
           
   
       [PunRPC]
       void All_Set_Item_Inventory()
       {
           this.gameObject.SetActive(false);
           Inventory inven = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
           for (int i = 0; i < inven.slots.Count; i++)
           {
               if (inven.slots[i].isEmpty)
               {
                   //PhotonNetwork.Instantiate(ItemPrefab.name, inven.slots[i].slotObj.transform.position, Quaternion.identity, 0);
                   Instantiate(ItemPrefab, inven.slots[i].slotObj.transform);
                   inven.slots[i].isEmpty = false;
                   inven.slots[i].item.itemName = ItemPrefab.gameObject.name;
                   
                   break;
               }
           }
           return;
       }
   }
