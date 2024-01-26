using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Condition
{

    public float CurValue;
    public float MaxValue;
    public float StartValue;
    public float RegenRate;
    public float DecayRate;
    public Image UiBar;

    public void Add(float amount) //최대값을 maxValue로 제한
    {
        CurValue = Mathf.Min(CurValue + amount, MaxValue);
    }

    public void Subtract(float amount) //최소값을 0으로 제한
    {
        CurValue = Mathf.Max(CurValue - amount, 0.0f);
    }

    public float GetPercentage()
    {
        return CurValue / MaxValue;
    }

    public float HealthPercentage()
    {
        return CurValue / MaxValue * 100;
    }
}


public class PlayerCondition : MonoBehaviour
{
    public Condition Health;
    public Condition Hunger;
    public Condition Thirsty;
    public Condition Stamina;

    public float NoFoodWaterHealthDecay;

    private void Update()
    {
        Hunger.Subtract(Hunger.DecayRate * Time.deltaTime);
        Thirsty.Subtract(Thirsty.DecayRate * Time.deltaTime);

        if (Hunger.CurValue == 0.0f && Thirsty.CurValue == 0.0f)
            Health.Subtract(NoFoodWaterHealthDecay * Time.deltaTime);

        if (Health.CurValue == 0.0f)
            Die();

        Health.UiBar.fillAmount = Health.GetPercentage();
        Hunger.UiBar.fillAmount = Hunger.GetPercentage();
        Thirsty.UiBar.fillAmount = Thirsty.GetPercentage();
        Stamina.UiBar.fillAmount = Stamina.GetPercentage();
    }
    private void Start()
    {
        Health.CurValue = Health.StartValue;
        Hunger.CurValue = Hunger.StartValue;
        Thirsty.CurValue = Thirsty.StartValue;
        Stamina.CurValue = Stamina.StartValue;
    }

    public void Potion(float amount)
    {
        Health.Add(amount);
    }

    public void Eat(float amount)
    {
        Hunger.Add(amount);
    }

    public void Drink(float amount)
    {
        Thirsty.Add(amount);
    }

    public void RestoreHealth(float amount)
    {
        Health.Add(Health.RegenRate * Time.deltaTime);
    }

    public void RestoreStamina(float amount)
    {
        Stamina.Add(Stamina.RegenRate * Time.deltaTime);
    }
    public bool UseStamina(float amount)
    {
        if(Stamina.CurValue -amount < 0)
            return false;

        Stamina.Subtract(amount);
        return true; 

        // attack = 3, run = 2, 아이템줍기 = 1, 스킬값 따로
    }

    public void Die()
    {
        //사망
    }
}
