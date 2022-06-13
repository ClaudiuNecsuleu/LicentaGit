using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region Singleton
    public static EquipmentManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion
    public GameObject[] myMeshes;
    public GameObject[] myMeshesDefault;

    [HideInInspector]
    public EquipmentScript[] currentEquipment = new EquipmentScript[5];

    private void Start()
    {
    }

    public void Update()
    {
        foreach (var equipment in currentEquipment)
        {
            if (equipment != null)
                showMesh(equipment.equipSlot);
        }
    }
    public void RemoveItemFromEquip() {

        for (int i = 0; i < currentEquipment.Length; i++)
        {
            if (currentEquipment[i] != null)
            {
                Debug.Log("enter" + (int)currentEquipment[i].equipSlot);
                myMeshes[(int)currentEquipment[i].equipSlot].SetActive(false);
                Debug.Log((int)currentEquipment[i].equipSlot + " jaa" + i);
                currentEquipment[i] = null;
            }
        }
    }
    public void showMesh(EquipmentSlot slot) {
        myMeshes[(int)slot].SetActive(true);
       // Debug.Log("slot "+(int)slot);
        if((int)slot < 3)
            myMeshesDefault[(int)slot].SetActive(false);
        
    }

}