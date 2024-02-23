using System;
using UnityEngine;
using UnityEngine.Events;

public class StatManager : Singleton<StatManager>
{
    public UnityEvent OnStatUpdateEvent;

    public PlayerStatData StatData;
    public EnemySO EnemySO;

    private void Start()
    {
        StatData = Resources.Load<PlayerStatData>("SO/PlayerData/StatData");
    }

    private void OnDisable()
    {
        OnStatUpdateEvent.RemoveAllListeners();
    }

    public void GainExp()
    {
        StatData.CurExp += EnemySO.Exp;

        if (StatData.MaxExp <= StatData.CurExp)
        {
            StatData.Level++;
            StatData.StatPoint += 5;
            StatData.CurExp = 0;
            StatData.MaxExp = CalcMaxExp();
        }
    }

    public int CalcMaxExp()
    {
        return (int)Math.Ceiling(StatData.MaxExp * 0.12) * 10;
    }

    public void OnAtkUpButton()
    {
        if(StatData.StatPoint > 0)
        {
            StatData.StatPoint -= 1;
            StatData.Atk += 5;
            OnStatUpdateEvent?.Invoke();
        }
    }

    public void OnHealthUpButton()
    {
        if (StatData.StatPoint > 0)
        {
            StatData.StatPoint -= 1;
            StatData.Conditions[(int)ConditionType.Health].MaxValue += 20;
            OnStatUpdateEvent?.Invoke();
        }
    }

    public void OnStaminaUpButton()
    {
        if (StatData.StatPoint > 0)
        {
            StatData.StatPoint -= 1;
            StatData.Conditions[(int)ConditionType.Stamina].MaxValue += 10;
            OnStatUpdateEvent?.Invoke();
        }
    }
}
