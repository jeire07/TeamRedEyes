using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class EnvironmentUI : MonoBehaviour
{
    [SerializeField] private TimeData _timeData;

    [SerializeField] private Image _weatherIcon;
    [SerializeField] private TMP_Text _weatherText;
    [SerializeField] private TMP_Text _timeText;
    [SerializeField] private TMP_Text _AMPMText;
    [SerializeField] private bool _is24HourFormat = false;

    private void Awake()
    {
        _timeData = Resources.Load<TimeData>("Utility/Time");
    }

    private void Start()
    {
        _weatherIcon = transform.Find("WeatherIcon").GetComponent<Image>();
        _weatherText = transform.Find("WeatherText").GetComponent<TMP_Text>();
        _timeText = transform.Find("TimeText").GetComponent<TMP_Text>();
        _AMPMText = transform.Find("AMPMText").GetComponent<TMP_Text>();
        
        TimeManager.Instance.OnMinutePassed += UpdateTimeUI;
    }

    private void UpdateWeatherIcon(string weatherName)
    {
        Sprite icon = Resources.Load<Sprite>($"Icon/UI/Weather/{weatherName}");
        _weatherIcon.sprite = icon;
        _weatherText.text = weatherName;
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
        string amPm = _timeData.IsAM ? "오전" : "오후";

        if (is24HourFormat)
        {
            return new string[] { amPm, $"D+{_timeData.Day}, {_timeData.Hour:D2} : {_timeData.Minute:D2}" };
        }
        else
        {
            int curHour = _timeData.Hour == 12 ? _timeData.Hour : _timeData.Hour % 12;
            return new string[] { amPm, $"Day {_timeData.Day} [ {curHour:D2} : {_timeData.Minute:D2} ]" };
        }
    }
}
