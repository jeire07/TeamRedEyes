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
        questData quest1 = new questData("�������� �Ͼ����(Ʃ�丮��)", "6������ ������ �������� �������� �ִ��� Ȯ���غ���","Quest1_1");

        questData quest1_1 = new questData("6������ ��������(��) ���� �������� �Ͼ���� Ȯ���غ���", "����Ʈ1.1�� �Ϸ��ϰ� ���ư� �̾߱�����", "Quest1_2");

        questData quest1_2 = new questData("6������ �������� �ִ� ���� Ȯ���� �����ƿ��� ���ư� �̾߱�����.", "����Ʈ1.2�� �Ϸ��ϰ� ���μ��� �̾߱�����.", "Quest1_3");

        questData quest1_3 = new questData("6������ ���μ��� �̾߱� ����.", "����Ʈ1.3�� �Ϸ��ϰ� ��� ����� ���� ����� �˾ƺ���.", "Quest1_4");
        
        questData quest1_4 = new questData("��� ����� ���� ����� �˾ƺ���.", "����Ʈ1.4�� �Ϸ��ϰ� 6���� �����̴� ����ü�� ó������.", "Quest1_5");

        questData quest1_5 = new questData("6���� �����̴� ����ü�� ó������.", "����Ʈ1.5�� �Ϸ��ϰ� 6������ ��ҿ��� ��ȭ�ϱ�", "Quest1_6");

        questData quest1_6 = new questData("6������ ��ҿ��� ��ȭ�ϱ�", "����Ʈ1.6�� �Ϸ��ϰ� �ش븦 ����Ͽ� ��ó�� ġ���غ���.", "Quest1_7");

        questData quest1_7 = new questData("�ش븦 ����Ͽ� ��ó�� ġ���غ���.", "����Ʈ1.7�� �Ϸ��ϰ� �������� ��ƺ���!", "Quest1_8");

        questData quest1_8 = new questData("�������� ��ƺ���!", "����Ʈ1.8�� �Ϸ��ϰ� 6������ �������� ��ȭ�غ���.", "Quest1_9");

        questData quest1_9 = new questData("6������ �������� ��ȭ�غ���.", "����Ʈ1.9�� �Ϸ��ϰ� ��Ḧ ��� ħ�븦 ������!", "Quest1_10");

        questData quest1_10 = new questData("��Ḧ ��� ħ�븦 ������!", "����Ʈ1.10�� �Ϸ��ϰ� ���� ����Ʈ�� �̵�", "Quest2");
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
