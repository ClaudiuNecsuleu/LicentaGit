using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    #region Singleton
    public static InventoryScript Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("More than one inventory");
            return;
        }
        Instance = this;
    }
    #endregion

    public List<ItemScript> items = new List<ItemScript>();
    public List<EquipmentScript> itemsEquip = new List<EquipmentScript>();

    public int spaceStandard = 16;
    public int spaceEquip = 5;

    public delegate void OnItemChange();
    public OnItemChange onItemChangeCallMe;

    public void Add(ItemScript item)
    {
        if (items.Count >= spaceStandard)
        {
            Debug.Log("Not space");
        }
        items.Add(item);
        if (onItemChangeCallMe != null)
            onItemChangeCallMe.Invoke();

    }

    public void AddToEquipInventory(ItemScript item)
    {

        if (itemsEquip.Count >= spaceEquip)
        {
            Debug.Log("Not space");
        }
        itemsEquip.Add((EquipmentScript)item);
        if (onItemChangeCallMe != null)
            onItemChangeCallMe.Invoke();

    }

    public void RemoveFromStandardInventory(ItemScript item)
    {
        items.Remove(item);
        if (onItemChangeCallMe != null)
            onItemChangeCallMe.Invoke();
    }

    public void RemoveFromEquipedInventory(ItemScript item)
    {
        itemsEquip.Remove((EquipmentScript)item);
        items.Add(item);
        if (onItemChangeCallMe != null)
         onItemChangeCallMe.Invoke();
    }
}


