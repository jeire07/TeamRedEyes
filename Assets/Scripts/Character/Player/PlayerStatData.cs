using UnityEngine;

[CreateAssetMenu(fileName = "StatData", menuName = "PlayerStatData")]
public class PlayerStatData : ScriptableObject
{
    public string Name = "Han";
    public int Level = 1;
    public int CurExp = 0;
    public int MaxExp = 5;
    public int Atk = 50;
    public int Def = 0;
    public int StatPoint = 0;
    public Condition[] Conditions;
}
