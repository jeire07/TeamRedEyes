using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Condition
{
    // 전부 JSON으로 따로 관리해야하는 데이터
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


public class PlayerConditions : MonoBehaviour
{
    public Condition Health;
    public Condition Hunger;
    public Condition Thirsty;
    public Condition Stamina;

    public float noFoodWaterHealthDecay;

    private void Update()
    {
        Hunger.Subtract(Hunger.DecayRate * Time.deltaTime);
        Thirsty.Subtract(Thirsty.DecayRate * Time.deltaTime);

        if (Hunger.CurValue == 0.0f && Thirsty.CurValue == 0.0f)
            Health.Subtract(noFoodWaterHealthDecay * Time.deltaTime);

        if (Health.CurValue == 0.0f)
            Die();

        if(Stamina.CurValue == 0.0f)
        {
            if(Hunger.CurValue < 50.0f && Thirsty.CurValue < 50.0f)
            {
                //이속 디버프
            }
        }

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

    public void Heal(float amount)
    {
        //if(베이스 공간에 들어가면)
        Health.Add(amount);
        //RestoreStamina(amount);
    }

    public void Eat(float amount)
    {
        Hunger.Add(amount);
    }

    public void Drink(float amount)
    {
        Thirsty.Add(amount);
    }

    public void RestoreStamina(float amount)
    {
        Stamina.Add(amount);
        //스태미나 회복 내용 (배부름에 따라서 회복량 증가)
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

    public void HungryPercent()
    {
        float hungrypercent = Hunger.HealthPercentage();

        if (hungrypercent >= 80)
        {
            // 체력 회복속도 상승, 플레이어 스피드 증가
        }
        else if (hungrypercent >= 50)
        {
            // 정상
        }
        else if (hungrypercent >= 20)
        {
            // 달릴 수 없음, 시야 범위 줄어듬
        }
        else if (hungrypercent > 0)
        {
            // 시야가 흐려지며 공격을 할 수 없다
        }
        else
        {
            Die();
        }
    }

    public void ThirstyPercent()
    {
        float thirstypercent = Thirsty.HealthPercentage();
        
        if (thirstypercent >= 50)
        {
            // 정상
        }
        else if (thirstypercent >= 20)
        {
            // 어지럼증
        }
        else if (thirstypercent > 0)
        {
            // 매우 어지럼증
        }
        else
        {
            Die();
        }
    }


}

// 나중에 class 따로따로 나눠서 refactoring 하자