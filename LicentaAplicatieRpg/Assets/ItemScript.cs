using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    [CreateAssetMenu(fileName = "Add New Item", menuName = "Inventory/Item")]
    public class ItemScript : ScriptableObject
    {
        new public string name = "New Item";
        public Sprite icon = null;
        public virtual void Use()
        {
            Debug.Log("Using" + name);
        }

    public void removeItemFromStandardInventory()
    {
        InventoryScript.Instance.RemoveFromStandardInventory(this);
    }

    public void moveItemtoEquipInventory()
    {
        InventoryScript.Instance.AddToEquipInventory(this);
    }

    public void addToCurrentEquipment(EquipmentScript equipment)
    {
        EquipmentManager.instance.currentEquipment[(int)equipment.equipSlot]=equipment;
        Debug.Log("equip");       
    }

}


