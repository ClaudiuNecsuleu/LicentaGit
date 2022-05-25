using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    [CreateAssetMenu(fileName = "Add New Item", menuName = "Inventory/Item")]
    public class ItemScript : ScriptableObject
    {
        new public string name = "New Item";
        public Sprite icon = null;
        public bool isStandardItem = false;
        public virtual void Use()
        {
            Debug.Log("Using" + name);
        }

    }


