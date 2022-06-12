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


}
public enum EquipmentSlot { Head, Chest, Legs, Weapon, Shield, Feet , None }


