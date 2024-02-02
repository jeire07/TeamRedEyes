using UnityEngine;

public class RestHandler : Singleton<RestHandler>
{
    private TimeData _timeData;

    private bool _isResting;
    private float _restingTime;

    private int _hour;
    private int _minute;

    // Start is called before the first frame update
    void Start()
    {
        _timeData = Resources.Load<TimeData>("Utility/Time");

        _hour = _timeData.Hour;
        _minute = _timeData.Minute;

        // observer 방식으로 HP 차감 이벤트 구독해서 휴식이 강제로 중단되도록 작업
        // OnTakeDamage += RestEnd;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isResting)
        {
            _restingTime -= Time.deltaTime;

            if (_restingTime <= 0)
            {
                RestEnd();
            }
        }
    }

    public void RestStart()
    {
        if (_timeData.RestHours > 0 && !_isResting)
        {
            _isResting = true;

            float timeScale = (float)(_timeData.RestHours * 3);
            TimeManager.Instance.SetGameSpeed(timeScale);

            _restingTime = _timeData.RestHours * _timeData.MinutesPerDay * 60 / _timeData.TimeScale;
        }
    }

    private void RestEnd()
    {
        _timeData.RestHours = 0;

        _isResting = false;
        TimeManager.Instance.SetGameSpeed(0);

        RestUI.Instance.CloseUI();
    }
}
