using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatPanel : MonoBehaviour
{
    [SerializeField] PlayerCondition _condition;

    #region Text
    public TextMeshProUGUI NameText;
    public TextMeshProUGUI HealthText;
    public TextMeshProUGUI LevelText;
    public TextMeshProUGUI ExpText;
    public TextMeshProUGUI AtkText;
    public TextMeshProUGUI DefText;
    public TextMeshProUGUI HungryText;
    public TextMeshProUGUI ThirstyText;
    public TextMeshProUGUI StaminaText;
    public TextMeshProUGUI StatPointText;
    public TextMeshProUGUI InfectionText;
    #endregion

    private void Awake()
    {
        GameObject player = GameObject.Find("Player");
        _condition = player.GetComponent<PlayerCondition>();
        //NameText.text = 플레이어데이터.Name;
    }

    private void Update()
    {
        UpdateStatPanel();
    }

    public void UpdateStatPanel()
    {
        HungryText.text = $"배고픔 {(int)_condition.Hunger.CurValue} / {(int)_condition.Hunger.MaxValue}";
        ThirstyText.text = $"갈증 {(int)_condition.Thirsty.CurValue} / {(int)_condition.Thirsty.MaxValue}";
        StaminaText.text = $"SP {(int)_condition.Stamina.CurValue} / {(int)_condition.Stamina.MaxValue}";
        InfectionText.text = $"감염도 {(int)_condition.Infection.CurValue} / {(int)_condition.Infection.MaxValue}";
        HealthText.text = $"체력 {(int)_condition.Health.CurValue} / {(int)_condition.Health.MaxValue}";
    }
}
