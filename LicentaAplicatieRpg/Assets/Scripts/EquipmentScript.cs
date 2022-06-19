using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class EquipmentScript : ItemScript
{
    public EquipmentSlot equipSlot;

    public int armorModifier;
    public int damageModifier;

    public override void Use()
    {
        base.Use();
        moveItemtoEquipInventory();
        removeItemFromStandardInventory();
        addToCurrentEquipment(this);
    }

    public void UseButtonFromEquipedInventory()
    {
        CharacterStats.Instance.damage.RemoveModifier((float)this.damageModifier);
        CharacterStats.Instance.armour.RemoveModifier((float)this.armorModifier);
        CharacterStats.Instance.onItemChangeStatusCallMe.Invoke();

        InventoryScript.Instance.RemoveFromEquipedInventory(this);
        EquipmentManager.instance.RemoveItemFromEquip(this);
        Debug.Log("remove item");
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

}
public enum EquipmentSlot { Head, Chest, Legs, Weapon, Shield, Feet, None }


