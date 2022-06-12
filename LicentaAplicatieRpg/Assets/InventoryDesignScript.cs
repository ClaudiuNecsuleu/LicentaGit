using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDesignScript : MonoBehaviour
{
    public GameObject inventoryUI;
    public Transform itemParent;
    public Transform itemParentEquiped;
    InventoryScript inventory;

    InventorySlot[] slots;
    InventorySlot[] slotsEquip;

    void Start()
    {
        inventory = InventoryScript.Instance;
        inventory.onItemChangeCallMe += UpdateUI;

        slots = itemParent.GetComponentsInChildren<InventorySlot>();
        slotsEquip = itemParentEquiped.GetComponentsInChildren<InventorySlot>();
    }

    void Update()
    {

    }

    void UpdateUI()
    {
  
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
        for (int j = 0; j < slotsEquip.Length; j++)
        {
            bool wasEquip = false;
            for (int i = 0; i < inventory.itemsEquip.Count; i++)
            {

                if (inventory.itemsEquip[i].equipSlot == slotsEquip[j].slotDestionation)
                {
                    slotsEquip[j].AddItem(inventory.itemsEquip[i]);
                    wasEquip = true;
                }
            }
            if(!wasEquip)
            slotsEquip[j].ClearSlot();
        }

        Debug.Log("UPDATING UI");
    }
}
