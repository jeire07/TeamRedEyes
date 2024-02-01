using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "StatData", menuName = "PlayerStatData")]
public class PlayerStatData : ScriptableObject
{
    public string Name = "";
    public int Level = 1;
    public int CurExp = 10;
    public int MaxExp = 100;
    public int Atk = 5;
    public int Def = 1;
    public int StatPoint = 5;
}
