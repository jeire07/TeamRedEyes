using UnityEngine;

[CreateAssetMenu(fileName = "NewNpcSO", menuName = "NPC/Create New NPC")]
public class NpcSO : ScriptableObject
{
    public string npcName;
    public string[] dialogues;
    public bool canRepair;
    public int repairCost;
}
