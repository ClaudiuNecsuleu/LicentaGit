using UnityEngine.UI;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{

    ItemScript item;
    public Image icon;
    public EquipmentSlot slotDestionation;

    public void AddItem(ItemScript newItem)
    {
        item = newItem;
        icon.sprite=item.icon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled=false;
    }

    public void UseButtonFromStandardInventory() {
        InventoryScript.Instance.RemoveFromStandardInventory(item); 
    }


    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }

}

