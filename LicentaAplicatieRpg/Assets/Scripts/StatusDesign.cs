using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatusDesign : MonoBehaviour
{
    public TextMeshProUGUI damage;
    public TextMeshProUGUI armour;

    void Start()
    {
        CharacterStats.Instance.onItemChangeStatusCallMe += StatusUpdateUI;
    }

    // Update is called once per frame
    void Update()
    {
       // damage.text = 1.ToString();
       // armour.text = 1.ToString();
    }

    public void StatusUpdateUI()
    {
        damage.text = CharacterStats.Instance.damage.CalculateValue().ToString();
        armour.text = CharacterStats.Instance.armour.CalculateValue().ToString();
    }
}
