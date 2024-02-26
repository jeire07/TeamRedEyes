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
    private Condition[] _conditions;

    public Condition Health { get; set; }
    public Condition Hunger { get; set; }
    public Condition Thirsty { get; set; }
    public Condition Stamina { get; set; }
    public Condition Infection { get; set; }

    private void Start()
    {
        _conditions = Resources.Load<PlayerStatData>("SO/PlayerData/StatData").Conditions;
    }

    private void Update()
    {
        for(ConditionType type = ConditionType.Health; type <= ConditionType.Infection; type++)
        {
            _conditions[(int)type].Add(_conditions[(int)type].RegenRate * Time.deltaTime);
        }

        if (Hunger.CurValue <= 0.0f || Thirsty.CurValue <= 0.0f)
            _conditions[(int)ConditionType.Health].RegenRate = -2;

        if (Health.CurValue == 0.0f)
            IsDead();
    }

    public void IsDead()
    {
        //사망애니메이션 하고 몇초뒤에 다시시작?, 게임이 끝나는?
    }
}
