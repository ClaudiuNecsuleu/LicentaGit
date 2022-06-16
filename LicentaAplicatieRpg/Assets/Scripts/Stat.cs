using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat
{
    public float value;

    private List<float> equipments = new List<float>();

    public float CalculateValue()
    {
        value = 0;
        foreach (var equip in equipments)
        {
            value += equip;
        }
        return value;
    }
    public void AddEquipment(float modifier)
    {
        if (modifier != 0)
        {
            equipments.Add(modifier);
        }
    }
    public void RemoveModifier(float modifier)
    {
        if (modifier != 0)
        {
            equipments.Remove(modifier);
        }
    }
}
