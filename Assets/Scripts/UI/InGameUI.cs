using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    private Condition[] _conditions;
    private Image[] _ConditionBar;

    private void Start()
    {
        _conditions = Resources.Load<PlayerStatData>("SO/PlayerData/StatData").Conditions;

        for (ConditionType type = ConditionType.Health; type <= ConditionType.Infection; type++)
        {
            _ConditionBar[(int)type] = transform.GetComponent<Image>();
        }
    }

    private void Update()
    {
        for (ConditionType type = ConditionType.Health; type <= ConditionType.Infection; type++)
        {
            _ConditionBar[(int)type].fillAmount = _conditions[(int)type].GetPercentage();
        }
    }
}
