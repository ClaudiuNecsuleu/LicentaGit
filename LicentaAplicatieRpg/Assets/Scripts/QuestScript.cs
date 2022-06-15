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

    public string nameNpc;
    public string descr;
    public string title;

    public Transform positionTarget;
    public float numberOfPrefab;
    public GameObject prefab;

    bool status = false;

    public QuestType questType;
    public override void Interact()
    {
        base.Interact();
        Debug.Log("Interact with NPC");
        ui.SetActive(true);
        npcName.text = "NPC-ul "+ nameNpc + ", are nevoie de ajutorul tau!";
        description.text = descr;
        questTitle.text = title;
        status = true;
    }

    public void TurnItOff() {
        ui.SetActive(false);
    }

    public void AcceptQuest()
    {
        ui.SetActive(false);
        // Debug.Log("QuestAccepted");
        if (status)
        {
            ActiveQuest.instance.quest = this.GetComponent<QuestScript>();
            status= false;
        }
    }

 
}
public enum QuestType { Find, Kill }