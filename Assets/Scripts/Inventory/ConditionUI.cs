using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ConditionUI : MonoBehaviour
{
    [SerializeField] private Condition[] _conditions;

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
        GameObject player = GameManager.Instance.PlayerCharacter;
        _conditions = player.GetComponent<PlayerCondition>().Conditions;
    }

    private void Update()
    {
        UpdateStatPanel();
    }

    public void UpdateStatPanel()
    {
        HealthText.text = $"체력 {_conditions[(int)ConditionType.Health].CurValue} / {_conditions[(int)ConditionType.Health].MaxValue}";
        HungryText.text = $"배고픔 {_conditions[(int)ConditionType.Hunger].CurValue} / {_conditions[(int)ConditionType.Hunger].MaxValue}";
        ThirstyText.text = $"갈증 {_conditions[(int)ConditionType.Thirsty].CurValue} / {_conditions[(int)ConditionType.Thirsty].MaxValue}";
        StaminaText.text = $"SP {_conditions[(int)ConditionType.Stamina].CurValue} / {_conditions[(int)ConditionType.Stamina].MaxValue}";
        InfectionText.text = $"감염도 {_conditions[(int)ConditionType.Infection].CurValue} / {_conditions[(int)ConditionType.Infection].MaxValue}";
    }
}
