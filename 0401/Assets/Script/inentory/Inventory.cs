using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Inventory : MonoBehaviour 
{
    public List<SlotData> slots = new List<SlotData> ();
    private int maxSlot = 3;
    public GameObject slotPrefab;
    private Image EmptyImg;
    private void Start()
    {
        GameObject slotPanel = GameObject.Find("Panel");
         
        for(int i= 0; i < maxSlot; i++)
        {
           GameObject go = Instantiate(slotPrefab, slotPanel.transform, false);
            go.name = "Slot_" + i;
            SlotData slot = new SlotData();
            slot.isEmpty = true;
            slot.slotObj = go;
            slots.Add(slot);
        }

        //if 아이템 사용하면 다시 빈화면으로 보여주게
        if (Input.GetMouseButtonDown(0)) {
            Slot.ItemUse();
            return;

        EmptyImg.sprite = item.itemImage;
    }
        Img.transform.position = Input.mousePosition;

    }
