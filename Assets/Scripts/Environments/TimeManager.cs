using System;
using UnityEngine;

public class TimeManager : Singleton<TimeManager>
{
    public event Action OnMinutePassed;

    [SerializeField] private TimeData _time;

    private float _currentTime;
    private float _timeRate;

    private void Awake()
    {
        _timeRate = 60 * 60 * 24 / (_time.MinutesPerDay * 60);

        Time.timeScale = 1.0f;
    }

    private void Update()
    {
        _currentTime += _timeRate * Time.deltaTime * _time.TimeScale;

        if(_currentTime > 60)
        {
            _time.Minute += (int)_currentTime / 60;
            _currentTime %= 60;
            CalcTime();
        }
    }

    private void CalcTime()
    {
        if (_time.Minute >= 60)
        {
            _time.Minute = 0;

            _time.Hour++;

            if(_time.Hour % 12 == 0)
            {
                ToggleIsAM();

                if (_time.Hour >= 24)
                {
                    _time.Hour = 0;
                    _time.Day++;
                }
            }
        }
        OnMinutePassed();
    }

    public void SetGameSpeed(int gameSpeed)
    {
        _time.TimeScale = gameSpeed;
        //if( _minutes > 0 )
        //{
        //    
        //}
        return "";
    }

    public void ToggleIsAM()
    {
        _time.IsAM = !_time.IsAM;
    }
}
