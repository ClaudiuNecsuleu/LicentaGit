using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUpInInventoryScript : InteractableScript
{
    public ItemScript item;
    public override void Interact()
    {
        base.Interact();
        PickUp();
    }
    void PickUp()
    {
        Debug.Log("Picking up item" + item.name);
        Destroy(gameObject);
    }
}
