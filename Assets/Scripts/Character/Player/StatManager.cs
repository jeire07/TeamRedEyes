using System;
using UnityEngine;
using UnityEngine.UI;

public class StatManager : Singleton<StatManager>
{
    //public event Action OnStatUI; 나중에 컨디션까지 합치고 사용

    public PlayerStatData StatData;
    public EnemySO EnemySO;
    private PlayerCondition _conditionData;
    private StatUI _statUI;

    private void Start()
    {
        StatData = Resources.Load<PlayerStatData>("SO/PlayerData/StatData");
    }
    public void GainExp()
    {
        StatData.CurExp += EnemySO.Exp;
    }
    public void LevelUp()
    {
        if(StatData.MaxExp >= StatData.CurExp)
        {
            StatData.Level++;
            StatData.StatPoint += 5;
        }
    }
    public void OnStatUpButton()
    {
        RaiseStat();
    }

    public void RaiseStat()
    {
        StatData.StatPoint -= 1;
        if(_statUI.AtkUpButton)
        {
            StatData.Atk += 5;
        }
        else if (_statUI.HealthUpButton)
        {
            _conditionData.Health.MaxValue += 10;
        }
        else if(_statUI.StaminaUpButton)
        {
            _conditionData.Stamina.MaxValue += 50;
        }
    }
}
