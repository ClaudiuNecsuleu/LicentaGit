using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestScript : InteractableScript
{
    public GameObject ui;

    public TextMeshProUGUI npcName;
    public TextMeshProUGUI description;
    public TextMeshProUGUI questTitle;

    public string name;
    public string descr;
    public string title;
    public override void Interact()
    {
        base.Interact();
        Debug.Log("Interact with NPC");
        ui.SetActive(true);
        npcName.text = "NPC-ul "+name+", are nevoie de ajutorul tau!";
        description.text = descr;
        questTitle.text = title;
    }

    public void TurnItOff() {
        ui.SetActive(false);
    }

    public void AcceptQuest()
    {
        ui.SetActive(false);
        Debug.Log("QuestAccepted");
    }
}
