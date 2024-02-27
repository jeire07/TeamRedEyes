using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatUI : MonoBehaviour
{
    [SerializeField] private Button[] _buttons;
    [SerializeField] private TMP_Text[] _basicStatTexts;
    [SerializeField] private TMP_Text[] _statTexts;

    [SerializeField] private Transform basicTextParent;

    private void Start()
    {
        //Transform basicTextParent = transform.Find("BasicInfo");

        //_basicStatTexts = new TMP_Text[basicTextParent.childCount];
        //_statTexts = new TMP_Text[transform.childCount - 1];

        //for (int index = 0; index < basicTextParent.childCount; index++)
        //{
        //    _basicStatTexts[index] = basicTextParent.GetChild(index).GetComponent<TMP_Text>();
        //}

        //for (int index = 1; index < transform.childCount; index++)
        //{
        //    _statTexts[index - 1] = basicTextParent.GetChild(index).Find("Value").GetComponent<TMP_Text>();
        //}
        UpdateStat();
        StatManager.Instance.OnStatUpdateEvent.AddListener(UpdateStat);
        StatManager.Instance.OnStatUpdateEvent.AddListener(ToggleButtonState);
    }

    public void ToggleButtonState()
    {
        if (GameManager.Instance.StatData.StatPoint == 0)
        {
            foreach(Button button in _buttons)
            {
                GameObject obj = button.gameObject;
                obj.SetActive(false);
            }
        }
        else
        {
            foreach (Button button in _buttons)
            {
                GameObject obj = button.gameObject;
                obj.SetActive(true);
            }
        }
    }

    private void Update()
    {
        UpdateStat();
    }

    private void UpdateStat()
    {
        PlayerStatData stat = GameManager.Instance.StatData;

        _basicStatTexts[0].text = $"Lv. {stat.Level}";
        _basicStatTexts[1].text = $"{stat.CurExp} / {stat.MaxExp}";
        _basicStatTexts[2].text = stat.StatPoint.ToString();

        _statTexts[0].text = stat.Atk.ToString();
        _statTexts[1].text = stat.Def.ToString();

        for (int i = 2; i < _basicStatTexts.Length; i++)
        {
            _statTexts[i].text = stat.Conditions[i-2].CurValue.ToString();
        }

        ToggleButtonState();
    }
}
