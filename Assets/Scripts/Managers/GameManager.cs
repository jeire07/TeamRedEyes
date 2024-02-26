using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private PlayerStatData _initData;
    public PlayerStatData StatData { get; set; }
    public GameObject PlayerCharacter;

    private void Awake()
    {
        _initData = Resources.Load<PlayerStatData>("SO/PlayerData/InitData");
        StatData = Resources.Load<PlayerStatData>("SO/PlayerData/StatData");
    }

    public void NewGame()
    {
        StatData.Name = _initData.Name;
        StatData.Level = _initData.Level;
        StatData.CurExp = _initData.CurExp;
        StatData.MaxExp = _initData.MaxExp;
        StatData.Atk = _initData.Atk;
        StatData.Def = _initData.Def;
        StatData.StatPoint = _initData.StatPoint;
        StatData.Conditions = (Condition[])_initData.Conditions.Clone();

        foreach(Condition condition in StatData.Conditions)
        {
            condition.CurValue = condition.StartValue;
        }
    }

    public void LoadGame(int LoadSlotNum)
    {
        PlayerStatData loadData;
        loadData = new PlayerStatData();
        //To Do : write code for load data from Json file
        //To Do : writecode for load data from Json file

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
