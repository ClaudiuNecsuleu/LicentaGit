using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ActiveQuest : MonoBehaviour
{
    #region Singleton
    public static ActiveQuest instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public QuestScript quest;
    bool questInProgress;
    GameObject prefab;
    public GameObject infoPanel;
    [HideInInspector]
    public GameObject[] rewards;
    public GameObject rewardPoint;
    [HideInInspector]
    public TextMeshProUGUI[] texts;
    Transform player;
    float lastTime;
    QuestType questType=QuestType.None;

    void Start()
    {
        texts = infoPanel.GetComponentsInChildren<TextMeshProUGUI>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        lastTime = 0;
    }

    void Update()
    {
        if (!questInProgress)
            if (quest != null)
            {
                questInProgress = true;

                StartQuest();
                quest = null;
            }

        if (questType == QuestType.Find)
            if (Vector3.Distance(prefab.transform.position, player.position) <= 2)
            {
                Destroy(prefab, 2);
                texts[0].text = "Complete! Pick up your reward!";
                texts[1].text = "";
                lastTime = Time.time;
                questType = QuestType.None;
                foreach (GameObject go in rewards)
                {
                    go.SetActive(true);
                    go.transform.position = rewardPoint.transform.position;
                }
                questInProgress = false;
            }

        if (questType == QuestType.Kill)
        {
            if (prefab == null)
            {
                texts[0].text = "Complete! Pick up your reward!";
                texts[1].text = "";
                lastTime = Time.time;
                questType = QuestType.None;
                foreach (GameObject go in rewards)
                {
                    go.SetActive(true);
                    go.transform.position = rewardPoint.transform.position;
                }
                questInProgress = false;
            }
        }

        if (lastTime != 0)
        {
            if (Time.time >= lastTime + 5)
            {
                infoPanel.SetActive(false);
                lastTime = 0;
            }
        }
    }

    private void StartQuest()
    {
        prefab = Instantiate(quest.prefab, quest.positionTarget.position, Quaternion.identity);
        questType = quest.questType;
        texts[0].text = quest.title;
        texts[1].text = quest.numberOfPrefab.ToString();
        rewards=quest.rewards;
        infoPanel.SetActive(true);
        // Debug.Log("start quest");
    }

}