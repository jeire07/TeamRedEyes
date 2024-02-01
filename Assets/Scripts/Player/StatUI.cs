using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatUI : MonoBehaviour
{
    private PlayerStatData _statData;

    public GameObject AtkUpButton;
    public GameObject HealthUpButton;
    public GameObject StaminaUpButton;

    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private TextMeshProUGUI _atkText;
    [SerializeField] private TextMeshProUGUI _defText;
    [SerializeField] private TextMeshProUGUI _expText;

    private void Start()
    {
        _statData = Resources.Load<PlayerStatData>("SO/PlayerData/StatData");
    }

    private void Update()
    {
        UpdateText();
    }


    public void ToggleButtonState()
    {
        if (StatManager.Instance.StatData.StatPoint == 0)
        {
            AtkUpButton.SetActive(false);
            HealthUpButton.SetActive(false);
            StaminaUpButton.SetActive(false);
        }
        else
        {
            AtkUpButton.SetActive(true);
            HealthUpButton.SetActive(true);
            StaminaUpButton.SetActive(true);
        }
    }

    public void UpdateText()
    {
        _nameText.text = $"이름 {_statData.Name}";
        _levelText.text = $"레벨 {_statData.Level}";
        _atkText.text = $"공격력 {_statData.Atk}";
        _defText.text = $"방어력 {_statData.Def}";
        _expText.text = $"경험치 {_statData.CurExp} / {_statData.MaxExp}";
    }
}
