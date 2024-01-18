using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class questManager : MonoBehaviour
{
    private List<questData> activeQuests = new List<questData>();
    public Text questUITitle;
    public Text questUIDescription;
    
    
    public questUI questUI;


    private void Start()
    {
       // questData newQuest = new questData("1.1) 6층에서 이재훈을(를) 만나 무슨일이 일어나는지 확인해보자 ");
        //StartQuest(newQuest);
    }

    public void StartQuest(questData quest)
    { 
        activeQuests .Add(quest);

        questUI.UpdateQuestUI(quest.questName, quest.questDescription);

        Debug.Log("quest Start: " +  quest.questName);
    }

    public void CompleteObjective(questData quest)
    { 
        quest.isCompleted = true;
        
        activeQuests.Remove(quest);
    }
}
