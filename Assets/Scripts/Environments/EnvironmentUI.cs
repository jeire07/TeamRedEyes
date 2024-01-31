using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class EnvironmentUI : MonoBehaviour
{
    [SerializeField] private TimeData _time;

    [SerializeField] private Image _WeatherIcon;

    [SerializeField] private TMP_Text _timeText;
    [SerializeField] private TMP_Text _AMPMText;
    [SerializeField] private bool _is24HourFormat = false;

    private void Awake()
    {
        _timeText = transform.Find("TimeText").GetComponent<TMP_Text>();
        _AMPMText = transform.Find("AMPMText").GetComponent<TMP_Text>();
        //_timeText = transform.GetChild(1).GetComponent<TMP_Text>();
        //_AMPMText = transform.GetChild(2).GetComponent<TMP_Text>();

        _WeatherIcon = transform.Find("WeatherInfo").GetComponent<Image>();
        //WeatherManager.Instance.OnWeatherChange += UpdateWeatherIcon;

        TimeManager.Instance.OnMinutePassed += UpdateTimeUI;
    }

    private void UpdateWeatherIcon(string weatherName)
    {
        //Sprite icon = Resources.Load<Sprite>($"WeatherIcon/{weatherName}"};
        //_WeatherIcon.sprite = icon;
    }

    private void UpdateTimeUI()
    {
        if (TimeManager.Instance != null)
        {
            string[] TimeData = GetFormattedTime(_is24HourFormat);

            _AMPMText.text = TimeData[0];
            _timeText.text = TimeData[1];
        }
    }

    public string[] GetFormattedTime(bool is24HourFormat = false)
    {
        string amPm = _time.IsAM ? "오전" : "오후";

        if (is24HourFormat)
        {
            return new string[] { amPm, $"D+{_time.Day}, {_time.Hour:D2} : {_time.Minute:D2}" };
        }
        else
        {
            int curHour = _time.Hour == 12 ? _time.Hour : _time.Hour % 12;
            return new string[] { amPm, $"Day {_time.Day} [ {curHour:D2} : {_time.Minute:D2} ]" };
        }
    }
}
