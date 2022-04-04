using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Inventory : MonoBehaviour
{
    public List<SlotData> slots = new List<SlotData>();
    private int maxSlot = 3;
    public GameObject slotPrefab;
    GameObject slotPanel;
    private void Start()
    {
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
            if (!slots[i].isEmpty && slots[i].item.itemName == "keyitem")
            {
                Destroy(GameObject.Find(slots[i].item.itemName + "(Clone)"));
                slots[i].isEmpty = true;
                slots[i].item.itemName = "";
                return true;
            }
        }
        return false;
    }

}