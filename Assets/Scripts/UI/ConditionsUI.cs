using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConditionsUI : MonoBehaviour
{
    [SerializeField] private Condition[] _conditions;

    [SerializeField] private Image[] _conditionBars;

    private void Start()
    {
        GameObject player = GameManager.Instance.PlayerCharacter;
        _conditions = player.GetComponent<PlayerCondition>().statData.Conditions;
        _conditionBars = new Image[_conditions.Length];

        for (int i = 0; i < transform.childCount; i++)
        {
            _conditionBars[i] = transform.GetChild(i).GetChild(1).GetComponent<Image>();
        }
    }

    private void Update()
    {
        UpdateStatPanel();
    }

    public void UpdateStatPanel()
    {
        for (int i = 0; i < _conditionBars.Length; i++)
        {
            _conditionBars[i].fillAmount = _conditions[i].CurValue / _conditions[i].MaxValue;
        }
    }
}
