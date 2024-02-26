using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public PlayerStatData InitData;
    public PlayerStatData StatData;
    public GameObject PlayerCharacter;

    private void Awake()
    {
        InitData = Resources.Load<PlayerStatData>("SO/PlayerData/InitData");
        StatData = Resources.Load<PlayerStatData>("SO/PlayerData/StatData");
    }

    private void Start()
    {
        PlayerCharacter = GameObject.FindGameObjectWithTag("Player");
    }

    public void NewGame()
    {
        StatData.Name = InitData.Name;
        StatData.Level = InitData.Level;
        StatData.CurExp = InitData.CurExp;
        StatData.MaxExp = InitData.MaxExp;
        StatData.Atk = InitData.Atk;
        StatData.Def = InitData.Def;
        StatData.StatPoint = InitData.StatPoint;
        StatData.Conditions = (Condition[])InitData.Conditions.Clone();
    }

    public void LoadGame(int LoadSlotNum)
    {
        PlayerStatData loadData;
        loadData = new PlayerStatData();
        //To Do : write code for load data from Json file

        StatData.Name = loadData.Name;
        StatData.Level = loadData.Level;
        StatData.CurExp = loadData.CurExp;
        StatData.MaxExp = loadData.MaxExp;
        StatData.Atk = loadData.Atk;
        StatData.Def = loadData.Def;
        StatData.StatPoint = loadData.StatPoint;
        StatData.Conditions = (Condition[])loadData.Conditions.Clone();
    }
}
