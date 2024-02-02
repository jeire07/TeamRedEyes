using UnityEngine;

public class RestHandler : Singleton<RestHandler>
{
    private Transform _restUI;
    private TimeData _timeData;

    private bool _isResting;
    private float _restingTime;

    private int _hour;
    private int _minute;

    // Start is called before the first frame update
    void Start()
    {
        Transform canvas = GameObject.FindGameObjectWithTag("NotFrequentUI").GetComponent<Transform>();
        _restUI = canvas.Find("RestUI");

        _timeData = Resources.Load<TimeData>("Utility/Time");

        _hour = _timeData.Hour;
        _minute = _timeData.Minute;
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

        _restUI.GetComponent<RestUI>().CloseUI();
    }
}
