using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class questManager : MonoBehaviour
{
    private List<questData> activeQuests = new List<questData>();
    public Text questUITitle;
    public Text questUIDescription;
    public questUI questUI;

    private static questManager _instance;
    public static questManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<questManager>();
            }
            return _instance;
        }
    }


    private void Start()
    {
        questData quest1 = new questData("무슨일이 일어난거지(튜토리얼)", "6층으로 내려가 무슨일이 벌어지고 있는지 확인해보자","Quest1_1");

        questData quest1_1 = new questData("6층에서 이재훈을(를) 만나 무슨일이 일어나는지 확인해보자", "퀘스트1.1을 완료하고 돌아가 이야기하자", "Quest1_2");

        questData quest1_2 = new questData("6층에서 벌어지고 있는 일을 확인후 이재훈에게 돌아가 이야기하자.", "퀘스트1.2를 완료하고 강민수와 이야기하자.", "Quest1_3");

        questData quest1_3 = new questData("6층에서 강민수와 이야기 하자.", "퀘스트1.3을 완료하고 장비 착용과 공격 방법을 알아보자.", "Quest1_4");
        
        questData quest1_4 = new questData("장비 착용과 공격 방법을 알아보자.", "퀘스트1.4을 완료하고 6층에 서성이는 감염체를 처리하자.", "Quest1_5");

        questData quest1_5 = new questData("6층에 서성이는 감염체를 처리하자.", "퀘스트1.5를 완료하고 6층에서 김소연과 대화하기", "Quest1_6");

        questData quest1_6 = new questData("6층에서 김소연과 대화하기", "퀘스트1.6을 완료하고 붕대를 사용하여 상처를 치료해보자.", "Quest1_7");

        questData quest1_7 = new questData("붕대를 사용하여 상처를 치료해보자.", "퀘스트1.7을 완료하고 아이템을 모아보자!", "Quest1_8");

        questData quest1_8 = new questData("아이템을 모아보자!", "퀘스트1.8을 완료하고 6층에서 박지은과 대화해보자.", "Quest1_9");

        questData quest1_9 = new questData("6층에서 박지은과 대화해보자.", "퀘스트1.9을 완료하고 재료를 모아 침대를 만들어보자!", "Quest1_10");

        questData quest1_10 = new questData("재료를 모아 침대를 만들어보자!", "퀘스트1.10을 완료하고 다음 퀘스트로 이동", "Quest2");
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

    public List<questData> GetActiveQuests()
    { 
        return activeQuests;
    }

    public string SaveQuestDatatoJson()
    {
        QuestManagerData questManagerData = new QuestManagerData(activeQuests);
        return JsonUtility.ToJson(questManagerData);
    }

    public void LoadQuestDatatoJson(string jsonData)
    {
        QuestManagerData questManagerData = JsonUtility.FromJson<QuestManagerData>(jsonData);
        activeQuests = questManagerData.activeQuests;
    }

}
public class QuestManagerData
{
    public List<questData> activeQuests = new List<questData>();

    public QuestManagerData(List<questData> quests)
    {
        activeQuests = quests;
    }
}
