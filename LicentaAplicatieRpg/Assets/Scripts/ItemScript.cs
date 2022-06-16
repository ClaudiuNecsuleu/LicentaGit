using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Add New Item", menuName = "Inventory/Item")]
public class ItemScript : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;

    public ItemType itemType;
    public virtual void Use()
    {
        Debug.Log("Using" + name);
        if (itemType == ItemType.Potions)
        {
            removeItemFromStandardInventory();
            CharacterStats.Instance.health += 25;
            CharacterStats.Instance.onHealthChangeStatusCallMe();
            Debug.Log("30 health added");
        }
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
        EquipmentManager.instance.currentEquipment[(int)equipment.equipSlot] = equipment;
        CharacterStats.Instance.damage.AddEquipment((float)equipment.damageModifier);
        CharacterStats.Instance.armour.AddEquipment((float)equipment.armorModifier);
        CharacterStats.Instance.onItemChangeStatusCallMe.Invoke();


        Debug.Log("equip     " + equipment.armorModifier);
    }

    public enum ItemType { None, Potions, Ticket, Equipment }

}


