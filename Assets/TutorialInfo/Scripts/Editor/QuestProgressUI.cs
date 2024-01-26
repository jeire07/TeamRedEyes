using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestProgressUI : MonoBehaviour
{
    public Text progressText;

    
    void Update()
    {
        UpdateQuestProgress();
    }

    private void UpdateQuestProgress()
    {
        List<questData> activeQuests = questManager.Instance.GetActiveQuests();

        string progress = "진행 중인 퀘스트:";

        foreach (questData quest in activeQuests)
        {
            progress += $"{quest.questName}";
        }

        progressText.text = progress;
    }
}
