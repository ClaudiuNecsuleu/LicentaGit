using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatusDesign : MonoBehaviour
{
    public TextMeshProUGUI damage;
    public TextMeshProUGUI armour;
    public GameObject ui;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            ui.SetActive(!ui.activeSelf);
        }

    }
    void Start()
    {
        CharacterStats.Instance.onItemChangeStatusCallMe += StatusUpdateUI;
    }
    public void StatusUpdateUI()
    {
        damage.text = CharacterStats.Instance.damage.CalculateValue().ToString();
        armour.text = CharacterStats.Instance.armour.CalculateValue().ToString();
    }
}
