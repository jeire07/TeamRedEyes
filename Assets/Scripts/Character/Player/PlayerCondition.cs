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

    public float NoFoodWaterHealthDecay { get; set; }
    public PlayerStateMachine playerStateMachine;

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

    public void RecoverHP(float amount)
    {
        Health.Add(amount);
    }

    public void RecoverHunger(float amount)
    {
        Hunger.Add(amount);
    }

    public void RecoverThirsty(float amount)
    {
        Thirsty.Add(amount);
    }

    public void TakeImmunity(float amount)
    {
        Infection.Add(-amount);
    }

    public void TakeInfection(float amount)
    {
        Infection.Add(amount);
    }

    public bool UseStamina(float amount)
    {
        if(Stamina.CurValue -amount < 0)
            return false;

        Stamina.Add(-amount);
        return true;

        // attack = 3, run = 2, 아이템줍기 = 1, 스킬값 따로
    }

    public void IsDead()
    {
        playerStateMachine.ChangeState(new PlayerDeadState(playerStateMachine));
    }
}
