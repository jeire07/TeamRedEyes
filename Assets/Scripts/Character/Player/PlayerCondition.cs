using UnityEngine;

public enum ConditionType
{
    Health,
    Stamina,
    Hunger,
    Thirsty,
    Infection
}

[System.Serializable]
public class Condition
{
    public string StatName;
    public float CurValue;
    public float MaxValue;
    public float StartValue;
    public float RegenRate;

    public void Add(float amount)
    {
        CurValue = Mathf.Clamp(CurValue + amount, 0, MaxValue);
    }

    public float GetPercentage()
    {
        return CurValue / MaxValue;
    }
}

public class PlayerCondition : Singleton<PlayerCondition>
{
    public Condition[] Conditions { get; set; }

    private void Awake()
    {
        Conditions = Resources.Load<PlayerStatData>("SO/PlayerData/StatData").Conditions;
    }

    private void Update()
    {
        for(ConditionType type = ConditionType.Health; type <= ConditionType.Infection; type++)
        {
            Conditions[(int)type].Add(Conditions[(int)type].RegenRate * Time.deltaTime);
        }

        if (Conditions[(int)ConditionType.Hunger].CurValue <= 0.0f || Conditions[(int)ConditionType.Thirsty].CurValue <= 0.0f)
            Conditions[(int)ConditionType.Health].RegenRate = -2;

        if (Conditions[(int)ConditionType.Health].CurValue == 0.0f)
            SetDead();
    }

    public void SetDead()
    {
        //stateMachine의 isDead를 true로 바꿔주는 코드
    }
}
