using System;
using UnityEngine;

public class TimeManager : Singleton<TimeManager>
{
    public event Action OnMinutePassed;
    public event Action OnDayPassed;

    [SerializeField] private TimeData _timeData;

    private float _currentTime;
    private float _timeRate;

    private void Awake()
    {
        _timeData = Resources.Load<TimeData>("Utility/Time");

        _timeData.TimeScale = 1f;
        _timeRate = 60 * 60 * 24 / (_timeData.MinutesPerDay * 60);
        Time.timeScale = _timeData.TimeScale;
    }

    private void Update()
    {
        _currentTime += _timeRate * Time.deltaTime;

        if(_currentTime > 60)
        {
            _timeData.Minute += (int)_currentTime / 60;
            _currentTime %= 60;
            CalcTime();
        }
    }

    private void CalcTime()
    {
        if (_timeData.Minute >= 60)
        {
            _timeData.Minute = 0;

            _timeData.Hour++;

            if(_timeData.Hour % 12 == 0)
            {
                ToggleIsAM();

                if (_timeData.Hour >= 24)
                {
                    _timeData.Hour = 0;
                    _timeData.Day++;
                    OnDayPassed();
                }
            }
        }
        OnMinutePassed();
    }

    public void SetGameSpeed(float gameSpeed)
    {
        _timeData.TimeScale = gameSpeed;
        Time.timeScale = _timeData.TimeScale;

        Debug.Log($"_timeData.TimeScale={_timeData.TimeScale}");
        Debug.Log($"Time.timeScale={Time.timeScale}");
    }

    public void ToggleIsAM()
    {
        _timeData.IsAM = !_timeData.IsAM;
    }

    private void OnDestroy()
    {
        OnMinutePassed = null;
        OnDayPassed = null;
    }
}
