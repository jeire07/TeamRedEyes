using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Condition
{
    // 전부 JSON으로 따로 관리해야하는 데이터
    public float curValue;
    public float maxValue;
    public float startValue;
    public float regenRate;
    public float decayRate;
    public Image uiBar;

    public void Add(float amount) //최대값을 maxValue로 제한
    {
        curValue = Mathf.Min(curValue + amount, maxValue);
    }

    public void Subtract(float amount) //최소값을 0으로 제한
    {
        curValue = Mathf.Max(curValue - amount, 0.0f);
    }

    public float GetPercentage()
    {
        return curValue / maxValue;
    }
}


public class PlayerConditions : MonoBehaviour
{
    public Condition health;
    public Condition hunger;
    public Condition thirsty;
    public Condition stamina;

    public float noFoodWaterHealthDecay;

    private void Update()
    {
        hunger.Subtract(hunger.decayRate * Time.deltaTime);
        thirsty.Subtract(thirsty.decayRate * Time.deltaTime);

        if (hunger.curValue == 0.0f)
            health.Subtract(noFoodWaterHealthDecay * Time.deltaTime);

        if (health.curValue == 0.0f)
            Die();

        health.uiBar.fillAmount = health.GetPercentage();
        hunger.uiBar.fillAmount = hunger.GetPercentage();
        thirsty.uiBar.fillAmount = thirsty.GetPercentage();
        stamina.uiBar.fillAmount = stamina.GetPercentage();
    }
    private void Start()
    {
        health.curValue = health.startValue;
        hunger.curValue = hunger.startValue;
        thirsty.curValue = thirsty.startValue;
        stamina.curValue = stamina.startValue;
    }

    public void Heal(float amount)
    {
        //if(베이스 공간에 들어가면)
        health.Add(amount);
        RestoreStamina(amount);
    }

    public void Eat(float amount)
    {
        hunger.Add(amount);
    }

    public void Drink(float amount)
    {
        thirsty.Add(amount);
    }

    public void RestoreStamina(float amount)
    {
        stamina.Add(amount);
        //스태미나 회복 내용 (배부름에 따라서 회복량 증가)
    }
    public bool UseStamina(float amount)
    {
        if(stamina.curValue -amount < 0)
            return false;

        stamina.Subtract(amount);
        return true; 
    }

    public void Die()
    {
        //사망
    }
}