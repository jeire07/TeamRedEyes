using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "New Quest")]
public class QuestData : ScriptableObject
{
    public string QuestTitle;
    public string[] Dialogues;
}