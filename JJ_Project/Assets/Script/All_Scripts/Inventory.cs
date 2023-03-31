using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Inventory : MonoBehaviour
{
    public List<SlotData> slots = new List<SlotData>();
    private int maxSlot = 5;
    public GameObject slotPrefab;
    GameObject slotPanel;
    private PhotonView PV;
    // Start is called before the first frame update

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
    }
    private void Start()
    {
        if (!PV.IsMine)
            return;

        slotPanel = GameObject.Find("Panel");

        for (int i = 0; i < maxSlot; i++)
        {
            GameObject go = Instantiate(slotPrefab, slotPanel.transform, false);
            go.name = "Slot_" + i;
            SlotData slot = new SlotData();
            slot.isEmpty = true;
            slot.slotObj = go;
            slot.item = new Item();
            slots.Add(slot);
            DontDestroyOnLoad(go);
        }
    }

    public void printInven()
    {
        foreach (SlotData s in slots)
            print(s.item.itemName);
    }

    public bool checkKey()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (!slots[i].isEmpty && slots[i].item.itemName == "keyslot")
            {
                Destroy(GameObject.Find(slots[i].item.itemName + "(Clone)"));
                slots[i].isEmpty = true;
                slots[i].item.itemName = "";
                return true;
            }
        }
        return false;
    }
    //힌트 메세지 확인해서 슬롯에 넣기
    public bool checkhint()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (!slots[i].isEmpty && slots[i].item.itemName == "hintitem")
            {
                Destroy(GameObject.Find(slots[i].item.itemName + "(Clone)"));
                slots[i].isEmpty = true;
                slots[i].item.itemName = "";
                return true;
            }
        }
        return false;
    }
    //힌트 메세지 확인해서 슬롯에 넣기
    public bool checkDuck()
    {
        if (findDuck("redslot") && findDuck("orangeslot") && findDuck("yellowslot") && findDuck("greenslot"))
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }

    private bool findDuck(string name)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].item.itemName == name)
            {
                return true;
            }
        }

        return false;
    }
    /*public void All_Set_Item_Inventory(GameObject ItemPrefab)
    {
        PV.RPC("Set_Item_Inventory", RpcTarget.All, ItemPrefab);
    }

    [PunRPC]
    void Set_Item_Inventory(GameObject ItemPrefab)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].isEmpty)
            {
                Instantiate(ItemPrefab, slots[i].slotObj.transform);
                slots[i].isEmpty = false;
                slots[i].item.itemName = ItemPrefab.gameObject.name;
                break;
            }
        }
    }*/
}