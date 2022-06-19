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
            UsePotion();
        }
    }

    public void UsePotion() {
        removeItemFromStandardInventory();
        CharacterStats.Instance.health += 25;
        CharacterStats.Instance.onHealthChangeStatusCallMe();
        Debug.Log("30 health added");
    }

    public void removeItemFromStandardInventory()
    {
        InventoryScript.Instance.RemoveFromStandardInventory(this);
    }

   
    public enum ItemType { None, Potions, Ticket, Equipment }

}


