using System;
using UnityEngine;

public class TimeManager : Singleton<TimeManager>
{
    public event Action OnMinutePassed;

    private float _currentTime;
    private float _startTime;

    [SerializeField] private int _minutesPerDay = 12;
    private float _TimeRate;
    public int TimeScale = 1;

    private bool _isAM;
    private int _days = 0;
    private int _hours = 12;
    private int _minutes = 0;

    private void Awake()
    {
        _TimeRate = 60 * 60 * 24 / (_minutesPerDay * 60);
        _currentTime = _startTime;

        CalcTime();
        Time.timeScale = 1.0f;
    }

    private void Update()
    {
        _currentTime += _TimeRate * Time.deltaTime * TimeScale;

        if(_currentTime > 60)
        {
            _minutes += (int)_currentTime / 60;
            _currentTime %= 60;
            CalcTime();
        }
    }

    private void CalcTime()
    {
        if (_minutes >= 60)
        {
            _minutes = 0;
            _hours++;

            if (_hours >= 24)
            {
                _hours = 0;
                _days++;
            }
        }
        OnMinutePassed();
    }

    public string SetGameSpeed()
    {
        if( _minutes > 0 )
        {

        }
    }

    public string[] GetFormattedTime(bool is24HourFormat = false)
    {
        string amPm = _isAM ? "오전" : "오전";

        if (is24HourFormat)
        {
            return new string[] { amPm, $"D+{_days}, {_hours:D2} : {_minutes:D2}" };
        }
        else
        {
            int curHour = _hours == 12 ? _hours : _hours % 12;
            return new string[] { amPm, $"D+{_days}, {curHour:D2} : {_minutes:D2}" };
        }
    }
}
