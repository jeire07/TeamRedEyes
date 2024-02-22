using System;
using UnityEngine;
using UnityEngine.UI;

public class StatManager : Singleton<StatManager>
{
    //public event Action OnStatUI; 나중에 컨디션까지 합치고 사용

    public PlayerStatData StatData;
    public EnemySO EnemySO;

    private void Start()
    {
        StatData = Resources.Load<PlayerStatData>("SO/PlayerData/StatData");
    }
    public void GainExp()
    {
        StatData.CurExp += EnemySO.Exp;

        if (StatData.MaxExp <= StatData.CurExp)
        {
            StatData.Level++;
            StatData.StatPoint += 5;
            StatData.CurExp = 0;
            StatData.MaxExp += 10;
        } 
    }
    public void OnAtkUpButton()
    {
        StatData.StatPoint -= 1;
        StatData.Atk += 5;
    }

    public void OnHealthUpButton()
    {
        StatData.StatPoint -= 1;
        PlayerCondition.Instance.Health.MaxValue += 20;
    }

    public void OnStaminaUpButton()
    {
        StatData.StatPoint -= 1;
        PlayerCondition.Instance.Stamina.MaxValue += 10;
    }
}
